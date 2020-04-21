using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ending scenes (winning and losing) shouldn't require the player movement related scripts.
public class endingManager : MonoBehaviour {

	public Animator animator;
	public Text nameText;
	public Text dialogueText;
	public Button button;
	public Button triggerButton;
	

	private Queue<string> sentences;

	// sentences will be the dialogue queue where we'll extract in FIFO order
	void Start () {
		sentences = new Queue<string>();
		
	}
	
	//sets certain UI menu's availabilty and starts the dialogue
	public void StartDialogue (Dialogue dialogue)
	{
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

//End of the endingscene would directly lead to the credits scene (12).
	void EndDialogue()
	{
        animator.SetBool("Notyet", false);
        animator.SetBool("EndofConvo", true);
        SceneManager.LoadScene(12);
	}

}