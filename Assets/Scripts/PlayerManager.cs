using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator anim;

        // Start is called before the first frame update
        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            inputHandler.isInteracting = anim.GetBool("isInteracting");
            inputHandler.rollFlag = false; // Resets the roll flag
            inputHandler.sprintFlag = false; // Resets the sprint flag
        }
    }
}
