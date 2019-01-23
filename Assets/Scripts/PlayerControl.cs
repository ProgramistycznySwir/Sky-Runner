﻿using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalForce = 50f;
    public float maxHorizontalSpeed = 30f;
    //public float rollDeadSpace = 0.1f;
    //public float rollingMaxAngle = 20f;
    //public float rollingSpeedPerSecond = 10f;

    public float initialSpeed = 50f;
    public float acceleration = 1f;
    float runnerSpeed = 0f;
    

    float roll = 0f;

    public float rollRatio = 1f;
    public bool rollCamera = true;

    bool enableStun = true; ///optimalisation snuff
        [Tooltip("Duration of stun (in frames)")]
    public ushort stunThreshold = 5;
    public ushort stun; //Current stun proggress
        [Tooltip("Limits the movement of ship on sides (Left, and Right)")]
    public Vector2 limitHorizontalMovement = new Vector2(-240f, 240f);    

        [Header("Keys:")]
    public KeyCode startRun = KeyCode.Space;
    bool runStarted = false;
    public bool customControl = false;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;
    float horizontalMovementVar = 0f; //used when customControl enabled, causes smooth motion of ship
        [Tooltip("Smaller the variable smoother the movement (default: 0.06)")]
    public float horizontalMovementSmoothness = 0.06f;


        [Header("Sockets:")]
        [Tooltip("If left empty auto gets rigidbody of object which component is")]
    public new Rigidbody rigidbody;
    public new Transform camera;
    int hitCount = 0;
    public UnityEngine.UI.Text hitCountText;
    public GameObject HitEffect;
    PlayerControl playerControl;
    public Shield shieldOfShip;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "walls" || collision.collider.tag != "Buff")
        {
            rigidbody.drag = 0f;
            rigidbody.angularDrag = 0f;
            playerControl.enabled = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Buff" && shieldOfShip.shieldLayers <= 0)
        {
            if (stun <= 0)
            {
                hitCount++;
                hitCountText.text = System.Convert.ToString(hitCount);
                Destroy(collider, 0.1f);
                Stun();
            }
            Instantiate(HitEffect, collider.transform.position, new Quaternion(0, 0, 0, 0));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(stunThreshold == 0) ///automatically sets enableStun to false if stunThreshold is equal to 0
        {
            enableStun = false;
        }
        if(rigidbody == null)
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }
        playerControl = gameObject.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (customControl)
        {
            if (Input.GetKey(right))
            {
                if (horizontalMovementVar < 0f) horizontalMovementVar = 0f;
                else horizontalMovementVar += horizontalMovementSmoothness;
                if (horizontalMovementVar > 1f)
                {
                    horizontalMovementVar = 1f;
                }
            }
            else
            {
                if (horizontalMovementVar > 0f)
                {
                    horizontalMovementVar -= horizontalMovementSmoothness;
                }
            }

            if (Input.GetKey(left))
            {
                if (horizontalMovementVar > 0f) horizontalMovementVar = 0f;
                else horizontalMovementVar -= horizontalMovementSmoothness;
                if (horizontalMovementVar < -1f)
                {
                    horizontalMovementVar = -1f;
                }
            }
            else
            {
                if(horizontalMovementVar < 0)
                {
                    horizontalMovementVar += horizontalMovementSmoothness;
                }                
            }

            if (horizontalMovementVar < horizontalMovementSmoothness && horizontalMovementVar > -horizontalMovementSmoothness) horizontalMovementVar = 0f;

            rigidbody.AddForce(new Vector3(horizontalMovementVar*horizontalForce, 0, 0));
        }
        else rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * horizontalForce, 0, 0));

        //Debug.Log("Rolling: " + Input.GetAxis("Horizontal") + " / " + horizontalMovementVar);

        //Debug.Log(rigidbody.velocity.x);

        if (rigidbody.velocity.x > maxHorizontalSpeed)
        {
            rigidbody.velocity = new Vector3(maxHorizontalSpeed, 0, 0);
        }
        else if (rigidbody.velocity.x < -maxHorizontalSpeed)
        {
            rigidbody.velocity = new Vector3(-maxHorizontalSpeed, 0, 0);
        }

        roll = -rigidbody.velocity.x * rollRatio;
        transform.eulerAngles = new Vector3(0, 0, roll);

        if(rollCamera) camera.eulerAngles = new Vector3(0, -roll * 0.25f, 0);


        if (runStarted)
        {
            runnerSpeed += acceleration * Time.deltaTime;
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, runnerSpeed);            
        }
        else if (Input.GetKeyDown(startRun))
        {
            StartRun();
            runStarted = true;
        }

        if (transform.position.x > limitHorizontalMovement.y) transform.position = new Vector3(limitHorizontalMovement.y, 0, transform.position.z);
        else if (transform.position.x < limitHorizontalMovement.x) transform.position = new Vector3(limitHorizontalMovement.x, 0, transform.position.z);

        if (enableStun && stun > 0)
        {
            stun--;
        }

        //if (rollDeadSpace <= Input.GetAxis("Horizontal") && -rollingMaxAngle <= roll) //Rolling Right
        //{
        //    Debug.Log(">>> Doin' my part!");
        //    roll -= rollingSpeedPerSecond * Time.deltaTime;
        //    //transform.eulerAngles += new Vector3(0, 0, transform.eulerAngles.z - rollingSpeedPerSecond * Time.deltaTime);
        //}
        //else if (-rollDeadSpace >= Input.GetAxis("Horizontal") && rollingMaxAngle >= roll) //Rolling Left
        //{
        //    roll += rollingSpeedPerSecond * Time.deltaTime;
        //}
    }

    private void StartRun()
    {
        runnerSpeed = initialSpeed;
    }
    public void Stun()
    {
        stun = stunThreshold;
    }
}