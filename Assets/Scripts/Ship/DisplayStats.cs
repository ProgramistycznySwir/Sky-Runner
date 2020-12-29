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

        text += WriteHPStatus(HP, GameRules.playerHPCap);

        for (int i = 0; i < armor; i++)
        {
            if (i == 3)
                text += "<color=\"purple\">";
            text += "H"; //Symbol of shield (armor)
        }
        if (armor > 3)
            text += "</color>";

        text += new System.String('E',  shield); //Symbol of ring (shield)

        if (stun > 0)
        {
            text += "<alpha=#" + ((int)(((float)stun / maxStun) * 256)).ToString("X") + ">";
            text += "C"; //Symbol of star
        }


        statusText.text = text;
    }

    public void DisplayDistance(int distanceUntouched, int shieldsStacks)
    {
        if (GameRules.distanceTravelled < 0)
            distanceText.text = $"ETA: {(-GameRules.distanceTravelled / GameRules.playerSpeed).ToString("F0")}s";
        else
        {
            distanceText.text = ((int)GameRules.distanceTravelled).ToString();
            if (shieldsStacks == GameRules.playerShieldCap)
                distanceUntouchedText.text = "Full";
            else
                distanceUntouchedText.text = ((GameRules.playerShieldDistancePerStack * (shieldsStacks + 1)) - distanceUntouched).ToString();
        }
    }

    public string WriteHPStatus(int HP, int maxHP)
    {
        string text = "";

        if (HP == maxHP)
            ;
        else if ((float)HP / maxHP > 0.75f)
            text += "<color=\"green\">";
        else if ((float)HP / maxHP > 0.4f)
            text += "<color=\"yellow\">";
        else
            text += "<color=\"red\">";

        text += new System.String('A', HP); //Symbol of cube (health)

        if(HP != maxHP)
            text += "</color>";

        return text;
    }
}
