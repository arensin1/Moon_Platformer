using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ending scenes (winning and losing) shouldn't require the player movement related scripts.
// simpler trigger class for only ending scenes
public class endingTrigger : MonoBehaviour {

	public Dialogue dialogue;	

	public void TriggerDialogue()
	{
		FindObjectOfType<endingManager>().StartDialogue(dialogue);
	}

}