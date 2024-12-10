using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask NPC;
    [SerializeField] private float interactRange = 1f;
    public bool interacting = false;
    private string currentNPC;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] interactableNPC = Physics2D.OverlapCircleAll(transform.position, interactRange, NPC);
        if (interacting && Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider2D my_NPC in interactableNPC)
            {
                FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider2D my_NPC in interactableNPC)
            {
                my_NPC.GetComponent<NPC_Dialogue_Trigger>().TriggerDialogue();
                currentNPC = my_NPC.name;
                interacting = true;
            }
        }
        else
        {
            foreach (Collider2D my_NPC in interactableNPC)
            {
                if (my_NPC.name != currentNPC)
                {
                    interacting = false;
                }
            }
        }
    }
}
