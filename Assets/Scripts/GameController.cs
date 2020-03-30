using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text uiText;
    public characterController player;
    private float timeLeft;
	public Text timeText;
    bool timechange; // to check when we have to keep run the timer

    // Start is called before the first frame update
    void Start()
    {
       uiText.text = "Goal: Find the Datalog";
	   timeText.text = "Time Left: ";
       timeLeft = 100.0f;
       timechange = true;
    }
    void FixedUpdate()
    {
        if (timechange){
            timeLeft -= Time.deltaTime;
		    timeText.text = "Time Left: " + timeLeft.ToString();
            if (timeLeft<0){
                timechange = false;
                timeText.text = "00;00";
                uiText.text = "Time's Up : (";
                Color newColor = new Color(1,0,0,1);
                uiText.color = newColor;
                player.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
    }
    // win situation
    public void winSituation()
    {
        if(player.obj_Complete){
			uiText.text = "Good Job :)";
            player.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            timechange = false;
        }

    }

    //lose situation 1 : falling down
    //lost situation 2 (on top of this code) : time's up
    public void loseSituation()
    {
        if(player.ourRigidbody.position.y < -6){
			uiText.text = "Aww you died :(";
            Color newColor = new Color(1,0,0,1);
            uiText.color = newColor;
            player.ourRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            timechange = false;
        }
    }
}
