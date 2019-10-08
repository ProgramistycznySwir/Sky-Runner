using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipColor : MonoBehaviour
{
    public Color shipColor;
    private float hue; //takes hue out of color so the ship could be dark and HUD is still visible


    public Renderer[] hull;
    public TextMeshPro[] texts;
    public TrailRenderer[] trails;


    // Start is called before the first frame update
    void Start()
    {
        SetColor(shipColor);
    }

    public void SetColor(Color newColor)
    {
        shipColor = newColor;
        float s, v; //Saturation, Value
        Color.RGBToHSV(newColor, out hue, out s, out v);

        for (int i = 0; i < hull.Length; i++)
        {
            foreach(Material material in hull[i].materials)
            {
                Debug.Log("Matterial name: " + material.name);
                if(material.name == "ShipColor (Instance)")
                {
                    /*hull[i].*/material.color = newColor;

                    break;
                }                
            }
        }
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].color = Color.HSVToRGB(hue, s, 1);
        }
        for (int i = 0; i < trails.Length; i++)
        {
            trails[i].startColor = Color.HSVToRGB(hue, s, 1);
        }
    }
}
