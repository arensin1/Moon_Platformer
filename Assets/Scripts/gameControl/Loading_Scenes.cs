using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading_Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    //use when endofConvo is true & Dialoguename = Dialogue 
    
    public Animator animator; // ui animator
    public characterController Sam;
    public void Load_Next_Scene()
    {
        //if player doesn't complete a step at Level 5
        //they'll be sent to alternative levels
        if(SceneManager.GetActiveScene().buildIndex ==5 && !animator.GetBool("Datalog")){
            SceneManager.LoadScene(8);
        }
        else if(SceneManager.GetActiveScene().buildIndex != 7)
        {
            //loading next scenes and resetting values
            animator.SetBool("Objective", false);
            animator.SetBool("Datalog", false);
            animator.SetBool("EndofConvo", false);
            Sam.obj_complete = false;
            Sam.clue_collect = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
        }
        
        
    }

  
}
