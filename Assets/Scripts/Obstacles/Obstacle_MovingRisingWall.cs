using UnityEngine;

public class Obstacle_MovingRisingWall : SpawnableObject
{
    private Vector3 movementVector;
    //private float sin;
    //private float cos;
    [Tooltip("In deegrees")]
    public float dirrectionRange;
    public Vector2 speedRange;
    public float speed;
    [Tooltip("base")]
    public Transform extender;
    public Transform[] walls;
    private int tailWallIndex;

    private float wallCycle;
    private float wallCycleClock;
    private bool halfCheck = false;

    //public float TESTadd; //pamiątka...


    public override void Set(int ID)
    {
        base.Set(ID);

        speed = Random.Range(speedRange.x, speedRange.y);

        float dirrectionInDegrees = Mathf.PI + (((Random.value) - 0.5f) * Mathf.PI * (dirrectionRange / 90)); //180 stopni to 1.5 * PI, dobrze wiedzieć, Daniel...

        float sin = Mathf.Sin(dirrectionInDegrees);
        float cos = Mathf.Cos(dirrectionInDegrees);
        movementVector = new Vector3(sin * speed, 0, cos * speed);

        transform.Rotate(Vector3.up, dirrectionInDegrees / Mathf.Deg2Rad);

        wallCycle = (25 / speed); //25 is wallSegmentLenght + single hole

        tailWallIndex = walls.Length - 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //{ //na pamiątkę jak świetnym matematykiem jestem
        //    float dirrectionInDegrees0 = (TESTadd * Mathf.PI) + (((0) - 0.5f) * Mathf.PI * (dirrectionRange / 90));

        //    float sin0 = Mathf.Sin(dirrectionInDegrees0);
        //    float cos0 = Mathf.Cos(dirrectionInDegrees0);

        //    Vector3 movementVector0 = new Vector3(sin0 * speed, 0, cos0 * speed);


        //    float dirrectionInDegrees1 = (TESTadd * Mathf.PI) + (((1) - 0.5f) * Mathf.PI * (dirrectionRange / 90));

        //    float sin1 = Mathf.Sin(dirrectionInDegrees1);
        //    float cos1 = Mathf.Cos(dirrectionInDegrees1);

        //    Vector3 movementVector1 = new Vector3(sin1 * speed, 0, cos1 * speed);


        //    Debug.DrawRay(Vector3.zero, movementVector0, Color.red);
        //    Debug.DrawRay(Vector3.zero, movementVector1, Color.blue);
        //}

        ///moving whole stuff
        extender.position += movementVector * Time.fixedDeltaTime;

        ///wall animation
        if(wallCycleClock < wallCycle/2)
        {
            if(halfCheck == true)
            {
                halfCheck = false;
                tailWallIndex--;
                if (tailWallIndex < 0)
                    tailWallIndex = walls.Length - 1;
            }

            walls[tailWallIndex].position -= new Vector3(0, (100 / (wallCycle / 2)) * Time.fixedDeltaTime, 0); // 100 is wall height, might make customisable later
        }
        else
        {
            if (halfCheck == false)
            {
                halfCheck = true;
                walls[tailWallIndex].position = extender.position + new Vector3(0, -walls[tailWallIndex].localScale.y / 2, 0);
            }

            walls[tailWallIndex].position += new Vector3(0, (100 / (wallCycle / 2)) * Time.fixedDeltaTime, 0); // 100 is wall height, might make customisable later
        }

        if (wallCycleClock > wallCycle)
            wallCycleClock = 0;

        wallCycleClock += Time.fixedDeltaTime;
    }
}
