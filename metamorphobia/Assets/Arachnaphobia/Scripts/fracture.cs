using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fracture : MonoBehaviour
{
   public GameObject fractured;
   public float breakForce;
    public bool broken = false;
    
    void Update()
    {
        
        
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Spider"){
            BreakThing();
        }
    }
    public void BreakThing(){
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);
        

        foreach(Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>()){
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
        }
        broken = true;
        Destroy(gameObject);
        
    }
}
