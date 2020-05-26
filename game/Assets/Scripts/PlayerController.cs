using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float jumpForce;
    public int coinValue = 1;
    private Rigidbody rb;
    private Collider col;
    private bool jumpPressed = false;
    private Vector3 size;
    // coin sound
    public AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        size = col.bounds.size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WalkHandler();
        JumpHandler();
    }

    private void WalkHandler(){
        // input on x (horizontal)
        float hAxis = Input.GetAxis("Horizontal");
        //if(hAxis != 0) print(hAxis);
        //input on z (vertical)
        float vAxis = Input.GetAxis("Vertical");
        //if(vAxis != 0) print(vAxis);

        // movement vector
        Vector3 movement = new Vector3(
            hAxis * walkSpeed * Time.deltaTime, 
            0, 
            vAxis * walkSpeed * Time.deltaTime
        );

        // calculate new position
        Vector3 newPos = new Vector3();
        newPos = transform.position + movement;

        // check to see if the player falls off the map
        if(newPos.y < 0) GameManager.instance.Die();

        //move player using rigidbody
        rb.MovePosition(newPos);
    }

    private void JumpHandler(){

        // input on the jump axis
        float jAxis = Input.GetAxis("Jump");
        //if the key has been pressed
        if(jAxis > 0){
            bool isGrounded = CheckGrounded();
            // make sure we are jumping (failsafe)
            if(!jumpPressed && isGrounded){
                jumpPressed = true;
                //jumping vector
                float jY = jAxis * jumpForce;
                Vector3 jVector = new Vector3(0,jY,0);
                //apply force to rigidbody, velocitychange ignores mass of body.
                rb.AddForce(jVector, ForceMode.VelocityChange);
            }
        }
        else{
            // jump key not pressed
            jumpPressed = false;
        }
    }

    private bool CheckGrounded(){
        
        //location of all 4 corners
        Vector3 corner1 = transform.position + new Vector3(size.x/2, -size.y/2 + 0.01f, size.z/2);
        Vector3 corner2 = transform.position + new Vector3(-size.x/2, -size.y/2 + 0.01f, size.z/2);
        Vector3 corner3 = transform.position + new Vector3(size.x/2, -size.y/2 + 0.01f, -size.z/2);
        Vector3 corner4 = transform.position + new Vector3(-size.x/2, -size.y/2 + 0.01f, -size.z/2);

        // check if we are grounded, throw raycast
        bool grounded1 = Physics.Raycast(corner1, -Vector3.up, 0.02f);
        bool grounded2 = Physics.Raycast(corner2, -Vector3.up, 0.02f);
        bool grounded3 = Physics.Raycast(corner3, -Vector3.up, 0.02f);
        bool grounded4 = Physics.Raycast(corner4, -Vector3.up, 0.02f);

        // return true if any of the corners are touching the ground.
        return(grounded1 || grounded2 || grounded3 || grounded4);
    }

    private void OnTriggerEnter(Collider other){
        //print("triggered");
        if(other.CompareTag("Coin")){
            GameManager.instance.IncreaseScore(coinValue);
            //play sound
            coinSound.Play();
            //remove coin from map
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Enemy")){
            print("enemy trigger");
            GameManager.instance.Die();
        }
        if(other.CompareTag("Goal")){
            print("Goal Trigger!!!!!!");
            GameManager.instance.IncreaseLevel();
        }
    }

}