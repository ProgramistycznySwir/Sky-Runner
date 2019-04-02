using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObject : MonoBehaviour
{
    public bool invert;
    public Transform objectToFace;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(objectToFace, transform.GetComponentInParent<Transform>().up);

        transform.LookAt(objectToFace);

        if (invert) transform.Rotate(new Vector3(0, 180, 0), Space.Self);
    }
}
