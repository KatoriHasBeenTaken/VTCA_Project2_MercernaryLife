using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static QuestManager;

public class NpcInteraction : MonoBehaviour
{
    [Header("Quest")]
    public Quest questData;

    [Header("Dialogue")]
    public Dialog dialogueData;

    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueData != null)
            {
                DialogueManager.Instance.StartDialogue(dialogueData);
            }

            if (questData != null && !questData.isQuestCompleted)
            {
                QuestManager.Instance.AddQuest(questData);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
