using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    public float rotationSpeed = 200;
    // Update is called once per frame
    void Update()
    {
        // angle of roation; v = d/t -> d = v*t
        float angleRot = rotationSpeed * Time.deltaTime;

        // rotate coin
        transform.Rotate(Vector3.up * angleRot, Space.World);
    }
}
