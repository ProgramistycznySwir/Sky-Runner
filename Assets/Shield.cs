using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Material material;
    public SphereCollider shield;
    public PlayerControl playerControl;
    public int maxShieldLayers = 5;
    public int shieldLayers = 0;
    public float alpha = 0;
    

    public const int shieldStunThreshold = 20;
    public int shieldStun = 0;


    void OnTriggerEnter(Collider collider)
    {
        if (shieldLayers > 0 && collider.tag == "Environment" && playerControl.stun <= 0)
        {
            playerControl.Stun();

            collider.GetComponent<PillarHitEffect>().Hitted();

            shieldLayers--;
            alpha = shieldLayers * 3;
            material.color = new Color(material.color.r, material.color.g, material.color.b, alpha / 100);
            if (shieldLayers <= 0)
            {
                shield.enabled = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        shield = gameObject.GetComponentInChildren<SphereCollider>();
        material = shield.GetComponentInParent<Renderer>().material;
        playerControl = gameObject.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldStun > 0)
        {
            shieldStun--;
        }
    }

    public void AddLayer()
    {
        if (shieldStun <= 0)
        {
            if (shieldLayers <= 0)
            {
                shield.enabled = true;
            }
            if (shieldLayers < maxShieldLayers)
            {
                shieldLayers++;
                alpha = shieldLayers * 3;
                material.color = new Color(material.color.r, material.color.g, material.color.b, alpha / 100);
            }
            shieldStun = shieldStunThreshold;
        }
    }
}
