using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    bool isTyping;
    string currentSentence;

    Queue<string> names;
    Queue<string> sentences;

    void Start () {
        names = new Queue<string>();
        sentences = new Queue<string>();
        isTyping = false;
        currentSentence = "";
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
            DisplayNextSentence();
    }

    public void StartDialogue(Dialogue[] dialogues) {
        animator.SetBool("IsOpen", true);

        names.Clear();
        sentences.Clear();

        foreach (Dialogue dialogue in dialogues) {
            names.Enqueue(dialogue.characterName);
            sentences.Enqueue(dialogue.sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (isTyping) {
            StopAllCoroutines();
            isTyping = false;
            dialogueText.text = currentSentence;
        }
        else if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        else {
            nameText.text = names.Dequeue();
            currentSentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(currentSentence));
        }
    }

    IEnumerator TypeSentence(string sentence) {
        isTyping = true;

        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }

        isTyping = false;
    }

    void EndDialogue() {
        animator.SetBool("IsOpen", false);
    }
}
