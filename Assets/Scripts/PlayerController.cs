

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

        public float moveSpeed;
        public float jumpSpeed;
        public float horizJumpSpeed;
        public bool grounded;
        
    
    
        // Update is called once per frame
        void Update()
        {
            
            Vector3 pos = transform.position;
            pos.x += moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;




        if (grounded)
        {
        
            transform.position = pos;
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + (GetComponent<Rigidbody>().transform.up * jumpSpeed);

                if (Input.GetAxis("Horizontal")>0)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + (GetComponent<Rigidbody>().transform.right * horizJumpSpeed);
                    
                }else if (Input.GetAxis("Horizontal") < 0)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + (GetComponent<Rigidbody>().transform.right * -horizJumpSpeed);

                }
            }
   
        }
        if (Input.GetButtonDown("Crouch"))
        {
            moveSpeed = 0;
        }
         else if (Input.GetButtonUp("Crouch"))
        {
            moveSpeed = 2;
        }




        Debug.Log(grounded);

         
        }
        private void OnCollisionEnter(Collision c)
        {
             if (c.gameObject.CompareTag("Ground"))
            {
             grounded = true;
            }
        }
        private void OnCollisionExit(Collision c)
        {
            if (c.gameObject.CompareTag("Ground"))
            {
                grounded = false;
            }
        }
}
