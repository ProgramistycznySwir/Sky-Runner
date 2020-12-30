using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    float dieBehind;
    SpawnableObject spawnableObject;

    void Start()
    {
        dieBehind = GameRules.obstacleTerminationLine;
        spawnableObject = GetComponent<SpawnableObject>();
    }

    void FixedUpdate()
    {
        // transform.position += new Vector3(0f, 0f, -GameRules.playerSpeed * Time.fixedDeltaTime);
        transform.Translate(new Vector3(0f, 0f, -GameRules.playerSpeed * Time.fixedDeltaTime));

        if(transform.position.z < dieBehind)
        {
            if(spawnableObject == null)
                GameObject.Destroy(gameObject);
            else
                GetComponent<SpawnableObject>().Dispose();

        }
    }
}
