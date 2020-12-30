using UnityEngine;

public class Obstacle_Rotor : SpawnableObject
{
    public float rpm = 60;

    public override void Set(int ID)
    {
        base.Set(ID);

        transform.position += Vector3.up * GameRules.bottomHeight;
        transform.Rotate(Vector3.forward * Random.Range(0, 90f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, (rpm * Time.deltaTime) * 6)); // at the end is 6 due to: 6 = 360 / 60
    }
}
