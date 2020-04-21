using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endingTrigger : MonoBehaviour {

	public Dialogue dialogue;	

	public void TriggerDialogue()
	{
		FindObjectOfType<endingManager>().StartDialogue(dialogue);
	}

}