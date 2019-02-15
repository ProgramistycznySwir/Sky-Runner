using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPillar : MonoBehaviour
{
    public float fallingSpeed = 100f;

    public float tiltingFactor = 5f;
    private Vector3 tilting;

    void Start()
    {
        tilting = new Vector3(Random.Range(-tiltingFactor, tiltingFactor), Random.Range(-tiltingFactor, tiltingFactor), Random.Range(-tiltingFactor, tiltingFactor));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(tilting * Time.fixedDeltaTime);
        transform.Translate(0, -fallingSpeed * Time.fixedDeltaTime, 0, Space.World);
        if (transform.position.y < -transform.localScale.y - 300) Destroy(gameObject);
    }
}
