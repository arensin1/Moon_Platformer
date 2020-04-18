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
	//public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		//animator.SetBool("IsOpen", true);
		button.gameObject.SetActive(true);
		triggerButton.interactable= false;
		nameText.text = dialogue.name;
		animator.SetBool("1stDialog", true);
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
		button.gameObject.SetActive(false);
		animator.SetBool("1stDialog", false);
		animator.SetBool("Datalog", false);
		animator.SetBool("End", false);
	}

}