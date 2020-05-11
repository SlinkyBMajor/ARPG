using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Movement movement;
    private PlayerActor playerActor;
    public AttackController attackController;

    // Start is called before the first frame update
    void Start()
    {
        playerActor = gameObject.GetComponent<PlayerActor>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lock controls if player is peforming action
        if(playerActor.state == "action")
        {
            return;
        }

        float speed = playerActor.baseSpeed;
        // Buttons
        if (Input.GetAxis("Roll") != 0)
        {
            // Increase speed
            speed += playerActor.sprintModifier;
        }
        if (Input.GetAxis("Basic attack") != 0)
        {
            attackController.PeformBasicAttack();
        }

        // Joystick
        
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            // Get stick tilt amount
            Vector3 tiltAmount = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
         
            if(playerActor.state == "attack")
            {
                speed = 1;
            }
               
            if (tiltAmount.magnitude > 0.1f)
            {
                movement.Move(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")), tiltAmount.magnitude * speed);
            };
        }
    }
}
