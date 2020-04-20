using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading_Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    //use when endofConvo is true & Dialoguename = Dialogue 
    
    public Animator animator;
    public characterController Sam;
    public void Load_Next_Scene()
    {
        if((SceneManager.GetActiveScene().buildIndex != 7 || SceneManager.GetActiveScene().buildIndex != 9))
        {
            animator.SetBool("Objective", false);
            animator.SetBool("Datalog", false);
            animator.SetBool("EndofConvo", false);
            Sam.obj_complete = false;
            Sam.clue_collect = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
        }else
         {
              SceneManager.LoadScene(0);
        }
        
        
    }
   /* void Restart_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name) ;
    }*/
}
