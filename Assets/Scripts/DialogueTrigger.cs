using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue[] dialogues;

    public void StartDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues);
    }
}
