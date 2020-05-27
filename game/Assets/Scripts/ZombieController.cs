using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * An enemy that moves on the X axis
 */
public class ZombieController : MonoBehaviour
{
    public float speedY = 3f;
    public float rangeY = 2f;
    public float speedX = 3f;
    public float rangeX = 2f;
    private Vector3 initialPos;
    private int directionX = 1;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    
    void Update()
    {
        //make it move on the y (vertically)
        float movementX, factorX, newX;
        if (directionX == -1) factorX = speedX + 1f; // if enemy is moving down, move faster
        else factorX = speedX;
        // how much y moved
        movementX = factorX * Time.deltaTime * directionX;
        // new y position
        newX = transform.position.x + movementX;
        //check to see if we went outside the range, change direction if true
        if (Mathf.Abs(newX - initialPos.x) > rangeX) directionX *= -1; // flip the position if newY takes us out of the range
        else transform.position += new Vector3(movementX, 0, 0); // otherwise, move along y.
    }
}
