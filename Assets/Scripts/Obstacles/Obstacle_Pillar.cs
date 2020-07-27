using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Pillar : MonoBehaviour
{
    public static Range sizeVarioationRange = new Range(10f, 15f);
    public static Range heightVariationRange = new Range(75f, 200f);

    void Start()
    {
        transform.position += Vector3.up * GameRules.bottomHeight;
        float size = sizeVarioationRange.Random;
        transform.localScale = new Vector3(size, heightVariationRange.Random, size);
        Destroy(this);
    }
}
