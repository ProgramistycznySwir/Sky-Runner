using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.parent.parent.parent.GetComponentInChildren<Shield>().shieldStun <= 0)
        {
            collider.transform.parent.parent.parent.GetComponentInChildren<Shield>().AddLayer();
        }
    }
}
