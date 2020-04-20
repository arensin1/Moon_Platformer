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
    public GameObject Death_Screen;
    public GameObject Game_Over_Screen;
    float timeValue;
    public Text counter;
    public Camera cam_over;

    
    void Start(){
        timeValue = 10f;
    }
    void FixedUpdate(){
        if(SceneManager.GetActiveScene().buildIndex == 7){
            if(dialog_ani.GetBool("EndofConvo") && !cam_over.gameObject.activeSelf){
                timeValue -= 1 * Time.deltaTime;
                counter.text = "Time Left: " +timeValue.ToString("0");
                if(timeValue <= 0){
                    loseSituation();
                }
            }
            
        }
    }
    
    // win situation
    public void winSituation()
    {
       if(Sam.obj_complete && dialog_ani.GetBool("EndofConvo")){

           StartCoroutine(LoadScene());
       }

    }
    private IEnumerator LoadScene()
    {
        
        yield return new WaitForSeconds(3.5f);
        loader.Load_Next_Scene();
    }

    //lose situation 1 : falling down
    //lost situation 2 (on top of this code) : time's up
    public void loseSituation()
    {
        if(Sam.ourRigidbody.position.y < -20 || timeValue <= 0){
            stoppingTheGame();
            Sam.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            DataHolder.Lives -= 1;
            if(DataHolder.Lives > 0){
                Time.timeScale =0;
                Death_Screen.SetActive(true);
            }
            else {
                Time.timeScale =0;
                Game_Over_Screen.SetActive(true);
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
