using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Pillar : SpawnableObject
{
    public new BoxCollider collider;
    public static Range sizeVarioationRange = new Range(10f, 15f);
    public static Range heightVariationRange = new Range(75f, 200f);

    public override void Set(int ID)
    {
        base.Set(ID);

        transform.position = new Vector3(GameRules.wallsPositions.Random, GameRules.bottomHeight, GameRules.obstacleSpawnDistance);

        float size = sizeVarioationRange.Random;
        float height = heightVariationRange.Random;

        transform.localScale = new Vector3(size, height, size);
        // collider.center = new Vector3(0, height/2, 0);
        // collider.size = new Vector3(0, height/2, 0);
    }
}
