using System;
using UnityEngine;

public class DisplaySpeed : MonoBehaviour
{
    public Rigidbody player;
    public UnityEngine.UI.Text speedDisplayer;

    void Start()
    {
        speedDisplayer = gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedDisplayer.text = Convert.ToString(Convert.ToInt32(player.velocity.z * 100)) + " m/s";
    }
}
