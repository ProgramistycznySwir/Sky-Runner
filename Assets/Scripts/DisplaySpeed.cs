using System;
using UnityEngine;

public class DisplaySpeed : MonoBehaviour
{
    public TMPro.TextMeshProUGUI speedText;

    // Update is called once per frame
    void Update()
    {
        speedText.text = Convert.ToString(Convert.ToInt32(GameRules.playerSpeed)) + " m/s";
    }
}
