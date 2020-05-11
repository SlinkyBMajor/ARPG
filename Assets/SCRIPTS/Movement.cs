using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform CameraPivot;
    private Animator animator;
    private float animationSpeed = 0f;
    private float targetSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animationSpeed = Mathf.Lerp(animationSpeed, targetSpeed, 0.1f); // Opt
        animator.SetFloat("Speed", animationSpeed);

        if(Mathf.Abs(Input.GetAxis("Vertical")) < 0.1f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f) {
            targetSpeed = 0f;
        }
    }

    public void Move(Vector3 direction, float speed)
    {
        // Animate
        targetSpeed = speed/4f;

        FaceDirection(direction);
        transform.localPosition += (CameraPivot.right * direction.x) * Time.deltaTime * speed;
        transform.localPosition += (CameraPivot.forward * direction.z) * Time.deltaTime * speed;
    }

    public void FaceDirection(Vector3 direction) {
        Vector3 lookDir = new Vector3();
        lookDir += (CameraPivot.right * direction.x);
        lookDir  += (CameraPivot.forward * direction.z);
        lookDir += transform.position;

        transform.LookAt(lookDir);
    }

}
