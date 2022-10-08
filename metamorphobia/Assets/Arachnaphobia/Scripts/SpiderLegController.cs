using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLegController : MonoBehaviour
{

    private Vector3 A;
    private Vector3 B;

    public Transform bone1;
    public Transform bone2;
    private Vector3 prevPos;

    public float maxX;

    public Transform Arep;
    public Transform Brep;
    


    // Start is called before the first frame update
    void Start()
    {
        A = new Vector3(0, 0, 10);
        B = new Vector3(0, 0, 10);
        prevPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.GetComponent<Transform>().position;
        Vector3 posChange = newPos - prevPos;
        A -= posChange;
        B -= posChange;

        if (A.x > 2*maxX){
            A.x -= 4*maxX;
        } else if (A.x < -2*maxX){
            A.x += 4*maxX;
        }

        if (Mathf.Abs(A.x) <= maxX){
            B = A;
        } else if (A.x < -maxX) {
            B = A;
            B.x = -A.x - 2 * maxX;
        } else if (A.x > maxX) {
            B = A;
            B.x = -A.x + 2 * maxX;
        }
        if (Arep != null){
            Arep.position = A+newPos;
        }
        if (Brep != null){
            Brep.position = B+newPos;
        }
        float theta = Mathf.Atan((B.x)/(B.z))*90+180;

        bone1.SetPositionAndRotation(newPos, Quaternion.Euler(new Vector3(-20,theta,0)));
        Debug.Log("" + theta + " " + B.x + " " + B.z);

        prevPos = newPos;

    }
}
