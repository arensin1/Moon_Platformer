using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public characterController characterController;
    public player player;
    public Animator animator;
    public GameObject Sam;
    

    // Start is called before the first frame update

    
    
    // win situation
    public void winSituation()
    {
        if(characterController.obj_Complete){
            stoppingTheGame();
        }

    }

    //lose situation 1 : falling down
    //lost situation 2 (on top of this code) : time's up
    public void loseSituation()
    {
        if(characterController.ourRigidbody.position.y < -5){
            stoppingTheGame();
        }
    }

    public void stoppingTheGame()
    {
        Sam.GetComponent<player>().enabled = false;
        animator.enabled = false;
        characterController.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
