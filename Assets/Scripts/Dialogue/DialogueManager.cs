using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialog initialDialog;  // Dialog before giving quest
    public Quest quest;           // Quest associated with this NPC

    private bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // Show interaction prompt (UI text like "Press E to interact")
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Hide interaction prompt
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithPlayer();
        }
    }

    private void InteractWithPlayer()
    {
        if (!quest.isCompleted)
        {
            ShowDialog(initialDialog);
            // Give quest to the player
            Debug.Log($"Quest '{quest.questName}' started!");
        }
        else
        {
            ShowDialog(quest.questDialog);
        }
    }

    private void ShowDialog(Dialog dialog)
    {
        // Handle UI dialog system (e.g., showing dialog sentences one by one)
        foreach (var sentence in dialog.sentences)
        {
            Debug.Log(sentence); // Replace with UI display logic
        }
    }
}
