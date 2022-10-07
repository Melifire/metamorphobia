using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public int spiderAgro;
    public GameObject[] spiders;
    public CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Spider"){
            foreach (GameObject spider in spiders){
                spider.GetComponent<SpiderFollow>().agro = 2;
            }
        }
    }
}
