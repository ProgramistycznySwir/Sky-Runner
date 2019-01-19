using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarHitEffect : MonoBehaviour
{
    private Material material;
    private Color originalColor;
    public float recoveryTime = 0.2f;
    public float whiteOnHit = 0f;
    float white = 1;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    void Update()
    {
        if(white < 1)
        {
            white += whiteOnHit * (Time.deltaTime / recoveryTime);
            Debug.Log("IM HERE: " + white + " / " + whiteOnHit * (Time.deltaTime / recoveryTime));
            //if (white > 1) white = 1;
            material.color = new Color(originalColor.r * white, originalColor.g * white, originalColor.b * white, material.color.a);

        }

        
        Debug.Log(material.color);
        Debug.Log(white);
    }

    public void Hitted()
    {
        white = whiteOnHit;
        material.color = new Color(originalColor.r * white, originalColor.g * white, originalColor.b * white, material.color.a);
        Debug.Log("I'm hit!");
    }
}

/*
    float h;
    float s;
    float v;
    Color.RGBToHSV(material.color, out h, out s, out v);
    h = 0;
    Update(){
        h += Time.deltaTime / timeOfCycle;
        if (h > 1) h = 0;
        material.color = new Color(Color.HSVToRGB(h, s, v));
    }
*/

