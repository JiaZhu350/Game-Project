using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Animator animator;
    [SerializeField] Player_Interaction player_Interaction;
    private Queue<string> sentences; //FIFO collection (first in first out)

    void Start()
    {
        sentences = new Queue<string>(); //intializes it the Queue
    }
    public void Start_Dialogue(NPC_Dialogues dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        Debug.Log("Starting Conversation with " + dialogue.name);
        sentences.Clear();
        foreach (string dialogues in dialogue.sentences)
        {
            sentences.Enqueue(dialogues);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(dialogueText);
    }
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        player_Interaction.interacting = false;
    }
}
