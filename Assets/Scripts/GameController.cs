using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text uiText;
    public characterController characterController;
    private float timeLeft;
    public player player;
	public Text timeText;
    bool timechange; // to check when we have to keep run the timer
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
       uiText.text = "Goal: Fix Life Support Systems";
	   timeText.text = "Time Left: ";
       timeLeft = 100.0f;
       timechange = true;
       m_Animator = player.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (timechange){
            timeLeft -= Time.deltaTime;
		    timeText.text = "Time Left: " + timeLeft.ToString();
            if (timeLeft<=0){
                stoppingTheGame();
                timeText.text = "00;00";
                uiText.text = "Time's Up : (";
                Color newColor = new Color(1,0,0,1);
                uiText.color = newColor;
            }
        }
    }
    // win situation
    public void winSituation()
    {
        if(characterController.obj_Complete){
            stoppingTheGame();
            uiText.text = "Good Job :)";
            
        }

    }

    //lose situation 1 : falling down
    //lost situation 2 (on top of this code) : time's up
    public void loseSituation()
    {
        if(characterController.ourRigidbody.position.y < -30){
            stoppingTheGame();
            uiText.text = "Aww you died :(";
            Color newColor = new Color(1,0,0,1);
            uiText.color = newColor;
            
        }
    }

    public void stoppingTheGame()
    {
        characterController.endOfGame = true;
        timechange = false;
        m_Animator.GetComponent<Animator>().enabled = false;
        characterController.endOfGame = true;
        characterController.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
