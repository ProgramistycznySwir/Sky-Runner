using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Vector3 velocity;

    private float dieAfterTravelling = 1200f;
    private float startDistance;

    void Start()
    {
        startDistance = transform.position.z;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(velocity * Time.fixedDeltaTime);
        transform.position += velocity * Time.fixedDeltaTime;

        if(transform.position.z + dieAfterTravelling < startDistance)
        {
            Destroy(gameObject);
        }
    }
}
