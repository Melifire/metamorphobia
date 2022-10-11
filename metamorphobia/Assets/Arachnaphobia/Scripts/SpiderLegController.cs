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
    public Transform arm;
    private Quaternion restingRot;

    


    // Start is called before the first frame update
    void Start()
    {
        A = new Vector3(0, 0, 0.9f);
        B = new Vector3(0, 0, 0.9f);
        prevPos = Vector3.zero;
        restingRot = this.GetComponent<Transform>().rotation;

    }

    // Update is called once per frame
    void Update()
    {
        A = this.GetComponent<Transform>().InverseTransformPoint(A);
        Debug.Log(A);
        if (A.x > 2*maxX){
            A.x -= 4*maxX;
        } else if (A.x < -2*maxX){
            A.x += 4*maxX;
        }
        A.z = .5f;

        if (Mathf.Abs(A.x) <= maxX){
            B = A;
        } else if (A.x < -maxX) {
            B = A;
            B.x = -A.x - 2 * maxX;
        } else if (A.x > maxX) {
            B = A;
            B.x = -A.x + 2 * maxX;
        }


        float theta = Mathf.Atan((B.x)/(B.z)) * 70;
        Debug.Log(theta);

        arm.localEulerAngles = new Vector3(arm.localEulerAngles.x, theta+180, arm.localEulerAngles.z);
        //arm.localRotation = Quaternion.Euler(this.restingRot.eulerAngles + new Vector3(0,theta,0));
        Debug.Log("" + theta + " " + B.x + " " + B.z);


        A = this.GetComponent<Transform>().TransformPoint(A);
        B = this.GetComponent<Transform>().TransformPoint(B);
        if (Arep != null){
            Arep.position = A;
        }
        if (Brep != null){
            Brep.position = B;
        }

    }
}
