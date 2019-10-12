using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public TextMeshPro statusText;
    public TextMeshPro distanceText;
    public TextMeshPro distanceUntouchedText;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateStatus(5, 5, 3, true, 40, 50);
    }

    // Update is called once per frame
    public void UpdateStatus(int HP, int armor, int shield, int stun, int maxStun)
    {
        string text = "";

        if (HP == GameRules.playerHPCap) ;
        else if ((float)HP / GameRules.playerHPCap > 0.75f) text += "<color=\"green\">";
        else if ((float)HP / GameRules.playerHPCap > 0.4f) text += "<color=\"yellow\">";
        else  text += "<color=\"red\">";

        for(int i = 0; i < HP; i++)
        {
            text += "A"; //Symbol of cube (health)
        }
        if(HP != GameRules.playerHPCap) text += "</color>";

        for (int i = 0; i < armor; i++)
        {
            if (i == 3) text += "<color=\"purple\">";
            text += "H"; //Symbol of shield (armor)
        }
        if (armor > 3) text += "</color>";

        for(int i = 0; i < shield; i++)
        {
            text += "E"; //Symbol of ring (shield)
        }

        if (stun > 0)
        {
            text += "<alpha=#" + ((int)(((float)stun / maxStun) * 256)).ToString("X") + ">";
            text += "C"; //Symbol of star
        }        


        statusText.text = text;
    }
    public void DisplayDistance(int distanceUntouched, bool shieldsFull)
    {
        //Debug.Log(distanceUntouched + " / " + GameRules._distanceTravelled);
        if (GameRules._distanceTravelled < 0) distanceText.text = "Booting...";
        else
        {
            distanceText.text = ((int)GameRules._distanceTravelled).ToString();
            if (shieldsFull) distanceUntouchedText.text = "Full";
            else distanceUntouchedText.text = distanceUntouched.ToString();
        }
    }
}
