using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // player
    public float smoothSpeed = 0.125f; // make it smooth
    public Vector3 offset = new Vector3(0, 6, -10);

    // rotate stuff
    public float speed = 50.0f;
    public Vector3 left = new Vector3(0, 0, 90);
    public Vector3 offset1 = new Vector3(0, 6, -7);

    private void Update()
    {
        //CheckKeyInput();
    }

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        // Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        // transform.position = smoothedPos;
        transform.position = desiredPos;
    }

    private void CheckKeyInput()
    {
        if (Input.GetKeyDown("2"))
        {
            // rotate camera
            //transform.Rotate(left);
            //this.offset = offset1;
        }
        if (Input.GetKeyDown("1"))
        {

        }
    }

}
