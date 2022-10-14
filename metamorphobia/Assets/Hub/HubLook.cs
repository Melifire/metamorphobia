using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubLook : MonoBehaviour
{

    public float rotateSpeed;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
        Vector3 newRot = cameraTransform.localEulerAngles;
        newRot.y += horizontal;
        newRot.y = Mathf.Clamp(newRot.y, 0, 60);
        cameraTransform.localEulerAngles = newRot;
        
    }
}
