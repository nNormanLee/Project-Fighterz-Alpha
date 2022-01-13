using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{

    private Animator Anim;
    bool forward;
    //public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsItWalking();
        IsItJumping();
        IsItCrouching();

    }

    private void IsItWalking()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            Anim.SetBool("WalkingBack", true);
            Anim.SetBool("WalkingForward", false);
            Anim.SetBool("IsIdle", false);
            forward = false;

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Anim.SetBool("WalkingForward", true);
            Anim.SetBool("WalkingBack", false);
            Anim.SetBool("IsIdle", false);
            forward = true;


        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("IsIdle", true);
            Anim.SetBool("WalkingForward", false);
            Anim.SetBool("WalkingBack", false);
        }
    }

    private void IsItCrouching()
    {
        if (Input.GetButton("Crouch"))
        {
            Anim.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Anim.SetBool("IsCrouching", false);
        }
    }

    private void IsItJumping()
    {
        if (Input.GetButton("Jump"))
        {
            Anim.SetBool("Jumping", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            Anim.SetBool("Jumping", false);
        }

        if (Input.GetButton("Jump") && forward)
        {
            Anim.SetBool("JumpingForward", true);
        }
        if (Input.GetButton("Jump") && !forward)
        {
            Anim.SetBool("JumpingBack", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            Anim.SetBool("JumpingForward", false);
            Anim.SetBool("JumpingBack", false);
        }
    }
       
}

