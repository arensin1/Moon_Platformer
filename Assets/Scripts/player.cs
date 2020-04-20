using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public characterController controller;
    public float runningSpeed = 40f;
    float hori = 0f;
    bool jump = false;
    public Animator animator;
    public bool isDialogueOn;
    public Animator ani_Dialog;
    public GameObject objective;
    public Text Live_text;


    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene ().buildIndex >=5){
            controller.clue_collect = true;
        }
        if(Input.GetKeyDown("e") && controller.trigger)
             {
                
                if(controller.clue_collect){
                    ani_Dialog.SetBool("Notyet",false);
                    ani_Dialog.SetBool("ChangeFace", true);
                    controller.obj_complete = true;
                 }else{
                    ani_Dialog.SetBool("Notyet",true);
                }
                ani_Dialog.SetBool("Objective", true);
                objective.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
              }
        //getting user input for jump and horizontal movement
        if(!isDialogueOn){
            Live_text.text = "Lives:" + " " + DataHolder.Lives +"\n" + "Press 'esc' to pause"; 
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
