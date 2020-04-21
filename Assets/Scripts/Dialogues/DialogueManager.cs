using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class manages what happens behind the conversation parts with Watson and Datalogs.
public class DialogueManager : MonoBehaviour {

	public Animator animator;
	public Text nameText;
	public Text dialogueText;
	public Button button;
	public Button triggerButton;
	public GameObject ChangedFace;
	public GameObject Datalog;
	public player Sam;
	

	private Queue<string> sentences;

	// sentences will be the dialogue queue where we'll extract in FIFO order
	void Start () {
		sentences = new Queue<string>();
		
	}
	//resetting some booleans for animator and player script.
	//sets certain UI menu's availabilty and starts the dialogue
	public void StartDialogue (Dialogue dialogue)
	{
		Sam.isDialogueOn = true;
		if(animator.GetBool("ChangeFace")){
			triggerButton.gameObject.SetActive(false);
			ChangedFace.gameObject.SetActive(true);
		}else{
			if(animator.GetBool("Datalog")){
				if(animator.GetBool("Objective")==false){
					Datalog.gameObject.SetActive(true);
					triggerButton.gameObject.SetActive(false);
				}else{
					triggerButton.gameObject.SetActive(true);
				}
			}
		}
		
		animator.SetBool("EndofConvo", false);
		button.gameObject.SetActive(true);
		triggerButton.interactable= false;
		nameText.text = dialogue.name;
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

//loops the queue of the dialogue until it's the end of the queue.
	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

//End of the dialogue will reset certain animator booleans 
	void EndDialogue()
	{
		Datalog.gameObject.SetActive(false);
		animator.SetBool("EndofConvo", true);
		animator.SetBool("Objective", false);
		Sam.isDialogueOn = false;
	}

}