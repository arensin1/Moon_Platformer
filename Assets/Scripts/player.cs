using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public characterController controller;
    public float runningSpeed = 40f;
    float hori = 0f;
    bool jump = false;
    public Animator animator;
    public bool isDialogueOn;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //getting user input for jump and horizontal movement
        if(!isDialogueOn){
            animator.enabled = true;
            hori = Input.GetAxisRaw("Horizontal") * runningSpeed;
            animator.SetFloat("Speed", Mathf.Abs(hori));// getting the absolute value of horizontal movement since going left will give neg values
            if (Input.GetButtonDown("Jump"))
            { 
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }else{
            animator.enabled=false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false); //when the jumping animation should end.
    }

    void FixedUpdate()
    {
        //using function to move player
        if (!isDialogueOn){
            controller.Move(hori * Time.fixedDeltaTime, jump);
            jump = false;
        }else{
            animator.enabled = false;
        }
        
    }

}
