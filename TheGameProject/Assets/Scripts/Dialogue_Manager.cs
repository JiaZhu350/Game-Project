using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField] Player_Interaction player_Interaction;
    private Queue<string> sentences; //FIFO collection (first in first out)
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); //intializes it the Queue
    }
    public void Start_Dialogue(NPC_Dialogues dialogue)
    {
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
        Debug.Log(sentence);
    }
    void EndDialogue()
    {
        Debug.Log("End of Conversation");
        player_Interaction.interacting = false;
    }
}
