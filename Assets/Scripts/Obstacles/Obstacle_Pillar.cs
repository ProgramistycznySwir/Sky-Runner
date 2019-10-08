using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Pillar : MonoBehaviour
{
    public Vector2 sizeVarioation = new Vector2(10f, 15f);
    public Vector2 heightVariation = new Vector2(75f, 200f);

    void Start()
    {
        transform.position += Vector3.up * GameRules.bottomHeight;
        float size = Random.Range(sizeVarioation.x, sizeVarioation.y);
        transform.localScale = new Vector3(size, Random.Range(heightVariation.x, heightVariation.y), size);
        Destroy(this);
    }
}
