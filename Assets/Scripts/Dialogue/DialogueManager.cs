﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
	public bool dialogueEnd;
    public Text nameText;
	public Text dialogueText;

	//public Animator animator;

    private Queue<string> sentences;
    // Start is called before the first frame update
    public void Start()
    {
		dialogueEnd = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
	{
        //animator.SetBool("IsOpen", true);
        GameObject.Find("Player").GetComponent<PlayerSkills>().frozen = true;
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
		dialogueEnd = true;
        GameObject.Find("Player").GetComponent<PlayerSkills>().frozen = false;
        //animator.SetBool("IsOpen", false);
        GameObject.Find("DialogueBox").SetActive(false); 
	}

}
