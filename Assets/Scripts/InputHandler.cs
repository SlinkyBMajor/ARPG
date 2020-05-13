using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;

        public float moveAmount;

        public float mouseX;
        public float mouseY;

        public bool b_Input;
        public bool rollFlag;
        public bool sprintFlag;
        public float rollInputTimer; // The time the roll button has been held

        PlayerControls inputActions;

        Vector2 movementInput;
        Vector2 cameraInput;

        public void OnEnable()
        {
            if(inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandleRollInput(delta);
        }

        private void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollInput(float delta)
        {
            // Detects if key is pressed and sets the bool
            b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            if(b_Input)
            {
                rollInputTimer += delta;
                if(moveAmount > 0)
                {
                sprintFlag = true;
                }
            }
            else
            {
                if(rollInputTimer > 0 && rollInputTimer < 0.5f) // If NOT roll being held, but the button has been pressed for between 0-0.5f, roll
                {
                    sprintFlag = false;
                    rollFlag = true;
                }

                rollInputTimer = 0; // Reset timer
            }
        }
    }
}