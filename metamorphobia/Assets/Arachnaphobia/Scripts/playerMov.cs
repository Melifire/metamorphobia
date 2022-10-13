using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    // initializing variables
    public CharacterController control;
    public float speed = 12f;
    public float climbSpeed = 20f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;


    public Transform groundCheck;
    public Transform wallCheck;
    public float groundDistance = 0.4f;
    public float wallDistance = 2;
    public LayerMask groundMask;
    public LayerMask wallMask;
    
    Vector3 velocity;
    Vector3 move;
    bool isGrounded;
    bool isClimbing = false;
  

    // Update is called once per frame
    void Update()
    {
    // booleans to check if grounded or if climbing
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    isClimbing = Physics.CheckSphere(wallCheck.position,2,wallMask);
    if(isGrounded && velocity.y < 0){
            velocity.y = -1f;
    }

    // reading inpu
     float x = Input.GetAxis("Horizontal");
     float z = Input.GetAxis("Vertical");
    // check to see if climbing
    if (isClimbing == true && isGrounded == false){
     gravity = 0f;
     move = transform.right * x + transform.up * z;
     control.Move(move * climbSpeed * Time.deltaTime);
    } else{
         gravity = -9.8f;
        move = transform.right * x + transform.forward * z;

        control.Move(move * speed * Time.deltaTime);
    // check to see if user can jump
     if(Input.GetButtonDown("Jump") && isGrounded){
        velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);

     }
     velocity.y += gravity * Time.deltaTime;
     control.Move(velocity * Time.deltaTime);
    }

    }
}