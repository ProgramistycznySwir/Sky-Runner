using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimator : MonoBehaviour
{
    public KeyCode start = KeyCode.Space;

    bool a1 = false, a2 = false;

    public float speed;
    public float atFirst;

    public Transform camera;
    public float cameraStopsAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(start))
        {
            if (a1) a2 = true;
            else a1 = true;
        }
        if (a1 && transform.position.x > atFirst)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (a2)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if(camera.position.x > cameraStopsAt)
            {
                camera.position += (Vector3.left + Vector3.back) * speed * Time.deltaTime / 1.4f;
            }
        }
    }
}
