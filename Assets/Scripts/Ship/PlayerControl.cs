using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public float horizontalForce = 50f; //300
    public float maxHorizontalSpeed = 30f; //150
    //public float rollDeadSpace = 0.1f;
    //public float rollingMaxAngle = 20f;
    //public float rollingSpeedPerSecond = 10f;


    float roll = 0f;

    public float rollRatio = 1f;
    public bool rollCamera = true;

    bool enableStun = true; ///optimalisation snuff
    public int stun; //Current stun proggress
        [Tooltip("Limits the movement of ship on sides (Left, and Right)")]
    // public Vector2 limitHorizontalMovement = new Vector2(-240f, 240f);
    public Range limitHorizontalMovement;

    public int HP, armor; //do tego jeszcze tarcze które się regenerują po przeleceniu bez uderzenia w nic przez: 500/1000/1500  metrów (po regeneracji licznik przeleconych metrów się zeruje i jest naliczany od nowa aka jeśli przelecisz 1000 metrów bez uderzenia niczego masz 1 tarczę i 500m na kosz drugiej)
    public int shield;
    public float distanceUntouched = 0;

        [Header("Keys:")]
    public KeyCode startRun = KeyCode.Space;
    bool runStarted = false;
    public bool customControl = false;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;
    ValueInRange horizontalMovementVar = new ValueInRange(-1, 1, 0);
    // float horizontalMovementVar = 0f; //used when customControl enabled, causes smooth motion of ship
        [Tooltip("Smaller the variable smoother the movement (default: 0.06)")]
    public float horizontalMovementSmoothness = 0.06f;


        [Header("Sockets:")]
        [Tooltip("If left empty auto gets rigidbody of object which component is")]
    public new Rigidbody rigidbody;
    public new Transform camera;
    int hitCount = 0;
    public TMPro.TextMeshPro hitCountText;
    public GameObject hitEffect;
    public MasterShipColor masterShipColor; //Legacy
    public DisplayStats displayStats;
    //PlayerControl playerControl;
    public Shield shieldOfShip;

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log( collider.name);
        if (collider.tag == "StageSeparator")
        {
            // Debug.Log("So i'm here");
            Regenerate();
            Stun();
        }
        else if (collider.tag != "Buff" && stun <= 0)
        {
            // Debug.Log("So yet here");
            hitCount++;
            hitCountText.text = System.Convert.ToString(hitCount);

            Instantiate(hitEffect, transform.position + Vector3.forward * 10f, Quaternion.identity).GetComponent<Light>().color = masterShipColor.shipColor;

            Stun();
            if (shield > 0)
                shield--;
            else if (armor > 0)
                armor--;
            else if (HP > 0)
                HP--;

            distanceUntouched = 0;

            displayStats.UpdateStatus(HP, armor, shield, stun, GameRules.playerStunFrames);
            //collider.GetComponentInParent<Pillar>().Hit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(rigidbody == null)
            rigidbody = gameObject.GetComponent<Rigidbody>();
        // rigidbody ??= gameObject.GetComponent<Rigidbody>();

        limitHorizontalMovement.min = GameRules.wallsPositions.min + 10f;
        limitHorizontalMovement.max = GameRules.wallsPositions.max - 10f;

        if(GameRules.playerStunFrames == 0) ///automatically sets enableStun to false if GameRules.playerStunFrames is equal to 0
            enableStun = false;

        HP = GameRules.playerHPCap;

        distanceUntouched = -GameRules.obstacleSpawnDistance; //couse i want to it start counting only from start

        displayStats.UpdateStatus(HP, armor, shield, stun, GameRules.playerStunFrames);
        //playerControl = gameObject.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region >>> Side Ways Movement <<<
        if (customControl)
        {
            if (Input.GetKey(right))
            {
                horizontalMovementVar.MoveTowards(1f, horizontalMovementSmoothness);
                // if (horizontalMovementVar < 0f)
                //     horizontalMovementVar = 0f;
                // else
                //     horizontalMovementVar += horizontalMovementSmoothness;

                // if (horizontalMovementVar > 1f)
                //     horizontalMovementVar = 1f;
            }
            else if (Input.GetKey(left))
            {
                horizontalMovementVar.MoveTowards(-1f, horizontalMovementSmoothness);
                // if (horizontalMovementVar > 0f)
                //     horizontalMovementVar = 0f;
                // else
                //     horizontalMovementVar -= horizontalMovementSmoothness;

                // if (horizontalMovementVar < -1f)
                //     horizontalMovementVar = -1f;
            }
            else
            {
                horizontalMovementVar.MoveTowards(0, horizontalMovementSmoothness);
                // if(horizontalMovementVar < 0)
                // {
                //     horizontalMovementVar += horizontalMovementSmoothness;
                // }
            }

            // if (horizontalMovementVar < horizontalMovementSmoothness && horizontalMovementVar > -horizontalMovementSmoothness) horizontalMovementVar = 0f;

            rigidbody.AddForce(new Vector3(horizontalMovementVar * horizontalForce, 0, 0));
        }
        else rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * horizontalForce, 0, 0));

        //Debug.Log("Rolling: " + Input.GetAxis("Horizontal") + " / " + horizontalMovementVar);

        //Debug.Log(rigidbody.velocity.x);

        if (rigidbody.velocity.x > maxHorizontalSpeed)
            rigidbody.velocity = new Vector3(maxHorizontalSpeed, 0, 0);
        else if (rigidbody.velocity.x < -maxHorizontalSpeed)
            rigidbody.velocity = new Vector3(-maxHorizontalSpeed, 0, 0);

        roll = -rigidbody.velocity.x * rollRatio;
        transform.eulerAngles = new Vector3(0, 0, roll);

        if(rollCamera)
            camera.eulerAngles = new Vector3(0, -roll * 0.25f, 0);
        #endregion


        // Limits the movement of shit soo it don't touch boundaries, couse touching boundaries is no no
        if(!limitHorizontalMovement.IsInRange(transform.position.x))
            transform.position = new Vector3(limitHorizontalMovement.Clamp(transform.position.x), 0, transform.position.z);

        if (enableStun && stun > 0)
        {
            stun--;
            displayStats.UpdateStatus(HP, armor, shield, stun, GameRules.playerStunFrames);
        }

        CheckDistanceForShield();

        displayStats.DisplayDistance((int)distanceUntouched, shield);

        distanceUntouched += Time.fixedDeltaTime * GameRules.playerSpeed;
    }

    public void Stun()
        { stun = GameRules.playerStunFrames; }
    public void CheckDistanceForShield()
    {
        if(distanceUntouched >= GameRules.playerShieldDistancePerStack * (shield + 1) && shield < GameRules.playerShieldCap)
        {
            shield++;
            distanceUntouched = 0;
            displayStats.UpdateStatus(HP, armor, shield, stun, GameRules.playerStunFrames);
        }
    }
    public void Regenerate()
    {
        if (HP < GameRules.playerHPCap)
            HP++;
        else if (armor < GameRules.playerHardArmorCap)
            armor++;
        else if (shield < GameRules.playerShieldCap)
            shield++;
    }
}
