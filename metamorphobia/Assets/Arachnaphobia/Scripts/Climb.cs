using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    [Header("Reference")]
    public Transform orientation;
    public CharacterController control;
    private playerMov gravControl;
    public LayerMask isWall;

    [Header("Climbing")]
    public float climbSpeed;
    private bool climbing;

    [Header("Detection")]
    public float detectionLen;
    public float sphereCastRad;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;
    Vector3 velocity;

  

    private void Update(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.up * z;
        wallCheck();
        stateMachine();
        if((climbing) ){
            gravControl.gravity = 0f;
            ClimbingMovement(move);
            
            
        }
            else{
                gravControl.gravity = -9.81f;
            }
    }

    private void stateMachine(){
        if(wallFront && Input.GetKey(KeyCode.W)){
            StartClimbing();
        }
        else{
            if(climbing) StopClimbing();
        }
    }
    

    private void wallCheck(){
        wallFront = Physics.SphereCast(transform.position, sphereCastRad, orientation.forward, out frontWallHit, detectionLen, isWall);

    }

    private void StartClimbing(){
        climbing = true;
    }
    private void StopClimbing(){
        climbing = false;
    }
    private void ClimbingMovement(Vector3 move){
        control.Move(move * climbSpeed * Time.deltaTime);
        
    }
    


}
