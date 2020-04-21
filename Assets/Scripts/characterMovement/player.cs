using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public characterController controller;
    public float runningSpeed = 40f; // running speed
    float hori = 0f;
    bool jump = false;
    public Animator animator; //player animations
    public bool isDialogueOn;
    public Animator ani_Dialog; // dialog animations
    public GameObject objective; // objective for level
    public Text Live_text; // Text for Lives Counter


    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene ().buildIndex >=5){
            //setting this to true so that collecting clues becomes optional
            //this is implemented to ensure player can go to alternative levels
            //based on if they collect certain clues
            controller.clue_collect = true;
        }
        if(Input.GetKeyDown("e") && controller.trigger)
             {
                //using trigger boolean from controller
                //if player presses e they can interact with the oobjective
                //character can then see dialog 
                if(controller.clue_collect){
                    //changing booleans to direct which dialog option occurs
                    //or if the game will end or not
                    ani_Dialog.SetBool("Notyet",false);
                    ani_Dialog.SetBool("ChangeFace", true);
                    controller.obj_complete = true;
                 }else{
                    ani_Dialog.SetBool("Notyet",true);
                }
                //triggering dialog
                ani_Dialog.SetBool("Objective", true);
                objective.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
              }

        
        if(!isDialogueOn){
            //Putting on ui text for lives counter and pause instructions
            Live_text.text = "Lives:" + " " + DataHolder.Lives +"\n" + "Press 'esc' to pause"; 
            animator.enabled = true; // turn animator on
            //getting user input for jump and horizontal movement
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
        //using function to move player if dialog ui is off
        if (!isDialogueOn){
            controller.Move(hori * Time.fixedDeltaTime, jump);
            jump = false;
        }else{
            animator.enabled = false;
        }
        
    }

}
