using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public TextMeshPro statusText;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateStatus(5, 5, 3, true, 40, 50);
    }

    // Update is called once per frame
    public void UpdateStatus(int HP, int maxHP, int armor, bool shield, int stun, int maxStun)
    {
        string text = "";

        if (HP == maxHP) ;
        else if ((float)HP / maxHP > 0.75f) text += "<color=\"green\">";
        else if ((float)HP / maxHP > 0.4f) text += "<color=\"yellow\">";
        else  text += "<color=\"red\">";

        for(int i = 0; i < HP; i++)
        {
            text += "A"; //Symbol of cube (health)
        }
        text += "</color>";
        for (int i = 0; i < armor; i++)
        {
            if (i > 2) text += "<color=\"purple\">";
            text += "H"; //Symbol of shield (armor)
        }
        if (armor > 3) text += "</color>";
        if (shield) text += "E"; //Symbol of ring (shield)
        if (stun > 0)
        {
            text += "<alpha=#" + ((int)(((float)stun / maxStun) * 256)).ToString("X") + ">";
            text += "C"; //Symbol of star
        }        

        statusText.text = text;
    }
}
