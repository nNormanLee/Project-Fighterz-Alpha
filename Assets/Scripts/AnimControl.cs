using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{

    private Animator Anim;
    bool forward;
    public PlayerController player;
    bool jumping;
    bool idle;

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
        if (player.grounded)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Anim.SetBool("WalkingBack", true);
                Anim.SetBool("WalkingForward", false);
                Anim.SetBool("IsIdle", false);
                //Anim.SetBool("Jumping", false);
                //Anim.SetBool("JumpingForward", false);
                //Anim.SetBool("JumpingBack", false);
                forward = false;
                idle = false;

            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                Anim.SetBool("WalkingForward", true);
                Anim.SetBool("WalkingBack", false);
                Anim.SetBool("IsIdle", false);
                //Anim.SetBool("Jumping", false);
                //Anim.SetBool("JumpingForward", false);
                //Anim.SetBool("JumpingBack", false);
                forward = true;
                idle = false;


            }
            else if (Input.GetAxis("Horizontal") == 0 && !jumping)
            {
                Anim.SetBool("IsIdle", true);
                Anim.SetBool("WalkingForward", false);
                Anim.SetBool("WalkingBack", false);
                idle = true;
                //Anim.SetBool("Jumping", false);
                //Anim.SetBool("JumpingForward", false);
                //Anim.SetBool("JumpingBack", false);
            }
        }
    }

    private void IsItCrouching()
    {
        if (Input.GetButton("Crouch"))
        {
            Anim.SetBool("IsCrouching", true);
            idle = false;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Anim.SetBool("IsCrouching", false);
            idle = false;
        }
    }

    private void IsItJumping()
    {
        
        if (player.grounded)
        {
            jumping = false;
            Anim.SetBool("Jumping", false);
            if (Input.GetButtonDown("Jump")&& idle)
            {
                Anim.SetBool("Jumping", true);
                Anim.SetBool("WalkingForward", false);
                Anim.SetBool("WalkingBack", false);
                Anim.SetBool("IsIdle", false);
                jumping = true;
            }
            

            else if (Input.GetButtonDown("Jump") && forward)
            {
                //Anim.SetBool("JumpingForward", true);
                Anim.SetBool("WalkingForward", true);
                Anim.SetBool("Jumping", true);
                Anim.SetBool("IsIdle", false);
                jumping = true;
            }
            else if (Input.GetButtonDown("Jump") && !forward)
            {
                
                //Anim.SetBool("WalkingForward", false);
                Anim.SetBool("WalkingBack", true);
                Anim.SetBool("Jumping", true);
                Anim.SetBool("IsIdle", false);
                jumping = true;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                Anim.SetBool("Jumping", false);
                jumping = false;
            }
        }
        
    }
       
}

