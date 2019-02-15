using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Vector3 velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.fixedDeltaTime);
    }
}
