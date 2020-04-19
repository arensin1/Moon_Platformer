using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Animator animator;
	public Text nameText;
	public Text dialogueText;
	public Button button;
	public Button triggerButton;
	public GameObject Datalog;
	public player Sam;
	
	

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		
	}
	
	public void StartDialogue (Dialogue dialogue)
	{
		Sam.isDialogueOn = true;
		if(animator.GetBool("Datalog")){
			if(animator.GetBool("Objective")==false){
				Datalog.gameObject.SetActive(true);
				triggerButton.gameObject.SetActive(false);
			}else{
				triggerButton.gameObject.SetActive(true);
			}
		}else{
			triggerButton.gameObject.SetActive(true);
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

	void EndDialogue()
	{
		Datalog.gameObject.SetActive(false);
		animator.SetBool("EndofConvo", true);
		animator.SetBool("Objective", false);
		Sam.isDialogueOn = false;
	}

}