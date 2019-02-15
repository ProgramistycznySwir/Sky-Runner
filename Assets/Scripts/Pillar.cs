using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [Tooltip("Spawned after pillar was hitted")]
    public GameObject pillarDummy;

    public void Hit()
    {
        Debug.Log("Hitted");
        GameObject newDummy = Instantiate(pillarDummy, transform.position, transform.rotation);
        newDummy.transform.localScale = transform.localScale;
        Destroy(gameObject);
    }

}
