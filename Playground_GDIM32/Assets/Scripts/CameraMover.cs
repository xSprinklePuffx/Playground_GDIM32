using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMover : MonoBehaviour
{
    private Vector3 camPos;

    [Header("Camera Settings")]

    public float camSpeed;


    void Start()
    {
        camPos = this.transform.position;
    }

    void Update()
    {
            if (Input.GetKey(KeyCode.D))
            {
                camPos.x += camSpeed / 500;
            }
            if (Input.GetKey(KeyCode.A))
            {
                camPos.x -= camSpeed / 500;
            }

            this.transform.position = camPos;
    }
}
