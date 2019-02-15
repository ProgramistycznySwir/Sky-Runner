using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    public float distanceInFront = 200f;
    public float naboki = 200f;

    public int wait = 5;
    int cooldown = 0;

    public int waitBuffs = 500;
    int cooldownBuffs = 0;

    public bool multiplayer = false;

    public Vector2 heightOfObstacles = new Vector2(50f, 50f);

    [Header("Sockets:")]
    public Transform player;
    public GameObject pillar;
    public GameObject[] buffs;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (multiplayer)
        {
            transform.position = new Vector3(0,0,player.position.z);
        }
        if(cooldown <= 0)
        {
            GameObject newObstacle;
            if(multiplayer) newObstacle = Instantiate(pillar, new Vector3(Random.Range(-naboki, naboki), 0, transform.position.z + distanceInFront), new Quaternion(0, 0, 0, 0));
            else newObstacle = Instantiate(pillar, player.position + new Vector3(Random.Range(-naboki, naboki), 0, distanceInFront), new Quaternion(0,0,0,0));
            newObstacle.transform.localScale = new Vector3(newObstacle.transform.localScale.x, Random.Range(heightOfObstacles.x, heightOfObstacles.y), newObstacle.transform.localScale.z);
            cooldown = wait;
        }
        else cooldown--;

        if (cooldownBuffs <= 0)
        {
            Instantiate(buffs[Random.Range(0, buffs.Length - 1)], new Vector3(Random.Range(-naboki, naboki), 0, transform.position.z + distanceInFront), new Quaternion(0, 0, 0, 0));
            cooldownBuffs = waitBuffs;
        }
        else cooldownBuffs--;
    }
}
