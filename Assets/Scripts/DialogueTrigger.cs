using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public Dialogue noDatalog;
	public Animator animator;
	public bool obj_complete;

	public void TriggerDialogue()
	{
		if ((!animator.GetBool("Datalog"))&&animator.GetBool("Objective")){
			FindObjectOfType<DialogueManager>().StartDialogue(noDatalog);
			obj_complete = false;
		}else{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			obj_complete = true;
		}

	}

}