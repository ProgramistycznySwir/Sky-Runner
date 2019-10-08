using UnityEngine;

public class Obstacle_CrystalSpike : MonoBehaviour
{
    public Renderer renderer;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.up * (GameRules.bottomHeight - 5);

        Color color = Color.HSVToRGB(Random.value, 1, 1);
        color.a = 0.7f;
        renderer.material.color = color;

        transform.eulerAngles = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 360f), 0);

        light.color = color;
        light.intensity = Random.Range(1f, 2f);

        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
