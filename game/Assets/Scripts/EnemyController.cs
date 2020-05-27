using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speedY = 3f;
    public float rangeY = 2f;
    public float speedX = 3f;
    public float rangeX = 2f;
    private Vector3 initialPos;
    private int directionY = 1;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //make it move on the y (vertically)
        float movementY, factorY, newY;
        if (directionY == -1) factorY = speedY + 1f; // if enemy is moving down, move faster
        else factorY = speedY;

        // how much y moved
        movementY = factorY * Time.deltaTime * directionY;
        // new y position
        newY = transform.position.y + movementY;
        //check to see if we went outside the range, change direction if true
        if (Mathf.Abs(newY - initialPos.y) > rangeY) directionY *= -1; // flip the position if newY takes us out of the range
        else transform.position += new Vector3(0, movementY, 0); // otherwise, move along y.
    }
}
