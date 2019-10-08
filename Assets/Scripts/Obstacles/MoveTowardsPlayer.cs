using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private float dieBehind;
    
    void Start()
    {
        dieBehind = GameRules.obstacleTerminationLine;
    }
    
    void FixedUpdate()
    {
        transform.position += new Vector3(0f, 0f, -GameRules.playerSpeed * Time.fixedDeltaTime);

        if(transform.position.z < dieBehind)
        {
            Destroy(gameObject);
        }
    }
}
