using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    public GameObject Camera;
    Vector3 camPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.transform.position.z > 12)
        {
            camPos.z = 0;
        }
        camPos.z += 0.001f;
        Camera.transform.position = camPos;
    }
}
