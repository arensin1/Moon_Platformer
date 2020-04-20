using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public characterController Sam;
    public player player;
    public Animator animator;
    public Animator dialog_ani;
    public Loading_Scenes loader;


    
    
    // win situation
    public void winSituation()
    {
       if(Sam.obj_complete && dialog_ani.GetBool("EndofConvo")){

           StartCoroutine(LoadScene());
       }

    }
    private IEnumerator LoadScene()
    {
        
        yield return new WaitForSeconds(1.5f);
        loader.Load_Next_Scene();
    }

    //lose situation 1 : falling down
    //lost situation 2 (on top of this code) : time's up
    public void loseSituation()
    {
        if(Sam.ourRigidbody.position.y < -20){
            stoppingTheGame();
            Sam.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            DataHolder.Lives -= 1;
            if(DataHolder.Lives > 0){
                SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
            }
            else {
                SceneManager.LoadScene(0);
            }
            
        }
    }

    public void stoppingTheGame()
    {
        player.enabled = false;
        animator.enabled = false;
        
    }

    public void startingTheGame(){
        player.enabled = true;
        animator.enabled = true;
        
    }
}
