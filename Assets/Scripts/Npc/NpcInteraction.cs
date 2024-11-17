using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestManager;

public class NpcInteraction : MonoBehaviour
{
    public Quest questToGive;
    private bool playerInRange = false;
    public Dialogue npcDialogue;
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            GiveQuest();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press 'E' to interact.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void GiveQuest()
    {
        QuestManager questManager = FindObjectOfType<QuestManager>();
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(npcDialogue); // Start dialogue
        }

        if (questManager != null)
        {
            questManager.AddQuest(questToGive); // Add quest after dialogue
            Debug.Log("Quest Received: " + questToGive.questName);
        }
    }
}
