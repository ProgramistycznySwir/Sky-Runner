﻿using UnityEngine;

public class Obstacle_CrystalSpike : SpawnableObject
{
    //<NOTE> It's hardcoded here, you can parametrize it later.
    public readonly Range spikeInclinationRange = new Range(-50f, 50f);
    //<NOTE> It's hardcoded here, you can parametrize it later.
    public readonly Range spikeOpacityRange = new Range(0.6f, 0.8f);

    public new Renderer renderer;
    public new Light light;
    // Start is called before the first frame update
    public override void Set(int ID)
    {
        base.Set(ID);

        transform.position = new Vector3(GameRules.wallsPositions.Random, (GameRules.bottomHeight - 5), GameRules.obstacleSpawnDistance);

        Color color = Color.HSVToRGB(Random.value, 1, 1);
        color.a = spikeOpacityRange.Random;
        renderer.material.color = color;

        transform.eulerAngles = new Vector3(spikeInclinationRange.Random, Random.Range(0f, 360f), 0);

        light.color = color;
        //<NOTE> It's hardcoded here, you can parametrize it later.
        light.intensity = Random.Range(1f, 2f);
    }
}