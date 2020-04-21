using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public characterController Sam;
    public player player;
    public Animator animator; //Sam animation
    public Animator dialog_ani; // dialog animation
    public Loading_Scenes loader;
    public GameObject Death_Screen;
    public GameObject Game_Over_Screen;
    float timeValue; 
    float current_time;
    public Text counter; // time counter text
    public Camera cam_over; //camera overview
    public AudioSource music; //music

    
    void Start(){
        timeValue = 90f; // set timer
    }
    void Update(){
        //transitioning music off at end of level
        //using lerp to decrease volume over time
        if(SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex < 10){
            if(dialog_ani.GetBool("EndofConvo") && !dialog_ani.GetBool("Notyet")){
                    current_time += Time.deltaTime;
                    music.volume = Mathf.Lerp(music.volume, 0f, current_time/3f);
                }
        }
    }
    void FixedUpdate(){
        //For scene 7 use a timer
        if(SceneManager.GetActiveScene().buildIndex == 7){
            if(dialog_ani.GetBool("EndofConvo") && !cam_over.gameObject.activeSelf){
                //if not in dialog or in camera overview there is a countdown
                timeValue -= 1 * Time.deltaTime;
                //Countdown text is updated
                counter.text = "Time Left: " +timeValue.ToString("0");
                //lose if situation is lost
                if(timeValue <= 0){
                    animator.SetBool("EndofConvo", true);
                    animator.SetBool("Notyet", false);
                    SceneManager.LoadScene(10); //less time-> losing scene
                }
            }
            
        }
    }
    
    // win situation
    public void winSituation()
    {
       if(Sam.obj_complete && dialog_ani.GetBool("EndofConvo")){
           //load next Scene if winning
           StartCoroutine(LoadScene());
       }

    }
    private IEnumerator LoadScene()
    {
        //wait to load to see fading transitions
        yield return new WaitForSeconds(3.5f);
        loader.Load_Next_Scene();
    }

    //lose situation 1 : falling down
    //lost situation 2 (on top of this code) : time's up
    public void loseSituation()
    {
        if(Sam.ourRigidbody.position.y < -20 ){
            stoppingTheGame();
            //freezing body and subtracting lives
            Sam.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            DataHolder.Lives -= 1;
            if(DataHolder.Lives > 0){
                //pause game to stop counter
                //death ui will appear
                Death_Screen.SetActive(true);
            }
            else {
                //pause game to stop counter
                //game over ui will appear 
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
