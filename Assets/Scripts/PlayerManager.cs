using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator anim;
        CameraHandler cameraHandler;
        PlayerLocomotion playerLocomotion;

        [Header("Player flags")]
        public bool isInteracting;
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;

        public void Awake()
        {
            cameraHandler = CameraHandler.singleton;
        }

        // Start is called before the first frame update
        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        // Update is called once per frame
        void Update()
        {
            isInteracting = anim.GetBool("isInteracting"); // If animator is playing an unbreakable animation
            float delta = Time.deltaTime;

            isSprinting = inputHandler.b_Input;
            inputHandler.TickInput(delta);
            playerLocomotion.HandleMovement(delta);
            playerLocomotion.HandleRollAndSprinting(delta);
            playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }
        }

        private void LateUpdate()
        {
            // Reset flags
            inputHandler.rollFlag = false; // Resets the roll flag
            inputHandler.sprintFlag = false; // Resets the sprint flag

            if (isInAir)
            {
                playerLocomotion.inAirTimer += Time.deltaTime;
            }
        }
    }
}
