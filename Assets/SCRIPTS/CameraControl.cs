using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Transform xRotationPivot;

    public float maxXRotation;
    public float minXRotation;

    private bool RStickDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("R Horizontal") != 0f || Input.GetAxis("R Vertical") != 0f)
        {
            Rotate(Input.GetAxis("R Vertical"), Input.GetAxis("R Horizontal"));
        }                                                                      
        if(Input.GetAxis("Target lock") != 0)                                  
        {                                                                      
            if (!RStickDown)                                                   
            {      
                RStickDown = true;
                SetToTargetForward();
            }
        }else
        {
            RStickDown = false;
        }
    }

    void SetToTargetForward()
    {
        Vector3 newCameraRotation = new Vector3(transform.eulerAngles.x, target.eulerAngles.y, transform.eulerAngles.z);
        transform.eulerAngles = newCameraRotation;
    }

    void Rotate(float xAxisAmount, float yAxisAmount) {
        transform.Rotate(0f, yAxisAmount, 0f);
        if(xAxisAmount > 0.1f || xAxisAmount < -0.1f)
        xRotationPivot.Rotate(xAxisAmount, 0f, 0f);
    }
 
}
