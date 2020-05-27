using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // player
    public float smoothSpeed = 0.125f; // make it smooth
    public Vector3 offset = new Vector3(0, 6, -10);

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        // Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        // transform.position = smoothedPos;
        transform.position = desiredPos;
    }

}
