using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFollow : MonoBehaviour
{

    public int agro;
    public GameObject player;
    public Rigidbody rb;
    public float maxDistance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.agro = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 playerPos = player.transform.position;
        Vector3 spiderPos = this.transform.position;
        // Get the spider to look at the player
        Vector3 dirOfPlayer = (playerPos - spiderPos).normalized;
        dirOfPlayer.y = this.GetComponent<BoxCollider>().center.y / 2;
        this.transform.forward = dirOfPlayer;
        if (this.agro == 1) {  // Spiders are not attacking
            float distance = Vector3.Distance(playerPos, spiderPos);
            if (distance > maxDistance){
                rb.velocity = (dirOfPlayer*this.speed);
            }
        } else if (this.agro == 2){
            rb.velocity = (dirOfPlayer*this.speed*3);
        }  
    }


}
