[System.Serializable]
public class StagesData
{
    public Stage[] stages;
}

[System.Serializable]
public struct Obstacle
{
    public string name;
    public int ID;
    public float distance;
    public bool varySize;
}

[System.Serializable]
public struct Stage
{
    public string name;
    public int chanceOccuring;
    public Obstacle[] obstacles;
    public LightData lightData;
    public float[] lenghtRange;
}

[System.Serializable]
public struct LightData
{
    public float sunLightIntensity;
    public float[] sunLightColor;
    public float ambientIntensity;
}
