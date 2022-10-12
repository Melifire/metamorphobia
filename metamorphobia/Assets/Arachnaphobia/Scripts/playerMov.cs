using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    Rigidbody rb;
    public CharacterController control;
    public float speed = 12f;
    public float climbSpeed = 20f;
    public float jumpHeight = 3f;

    public float gravity = -9.81f;
   

    public Transform groundCheck;
    public Transform wallCheck;
    public float groundDistance = 0.4f;
    public float wallDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask wallMask;
    
    Vector3 velocity;
    Vector3 move;
    bool isGrounded;
    bool isClimbing = false;
  

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isClimbing = Physics.CheckSphere(wallCheck.position,wallDistance,wallMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -1f;
        }


     float x = Input.GetAxis("Horizontal");
     float z = Input.GetAxis("Vertical");
        // movement vector
    if (isClimbing == true){
     move = transform.right * x + transform.up * z;

     control.Move(move * climbSpeed * Time.deltaTime);
    } else{

        
        move = transform.right * x + transform.forward * z;

        control.Move(move * speed * Time.deltaTime);
        
     if(Input.GetButtonDown("Jump") && isGrounded){
        velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);

     }

     velocity.y += gravity * Time.deltaTime;

     control.Move(velocity * Time.deltaTime);
    }

    }
}