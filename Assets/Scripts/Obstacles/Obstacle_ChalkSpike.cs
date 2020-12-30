using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_ChalkSpike : SpawnableObject
{
    //<NOTE> It's hardcoded here, you can parametrize it later.
    public readonly Range spikeInclinationRange = new Range(-50f, 50f);

    // Start is called before the first frame update
    public override void Set(int ID)
    {
        base.Set(ID);

        bool up = Random.value > 0.5f;

        transform.position = new Vector3(GameRules.wallsPositions.Random, (GameRules.bottomHeight - 5) * (up ? -1 : 1), GameRules.obstacleSpawnDistance);

        // Color color = Color.HSVToRGB(Random.value, 1, 1);
        // color.a = spikeOpacityRange.Random;

        transform.eulerAngles = new Vector3(spikeInclinationRange.Random, Random.Range(0f, 360f), 0);
        if(up)
            transform.Rotate(0, 0, 180f);
    }
}
