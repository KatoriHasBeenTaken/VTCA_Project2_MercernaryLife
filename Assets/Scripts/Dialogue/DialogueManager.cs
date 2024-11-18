using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("Dialogue UI")]
    public GameObject dialogueUI; // Panel for dialogue
    public Text speakerText; // Text for speaker's name
    public Text dialogueText; // Text for dialogue lines
    public Button continueButton; // Button to continue dialogue

    private Dialog currentDialogue;
    private int currentLineIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false); // Ensure the dialogue UI starts hidden
        }

        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners(); // Prevent duplicate listeners
            continueButton.onClick.AddListener(ContinueDialogue);
        }
    }

    /// <summary>
    /// Starts a dialogue sequence.
    /// </summary>
    /// <param name="dialogue">The dialogue data to display.</param>
    public void StartDialogue(Dialog dialogue)
    {
        if (dialogue == null)
        {
            Debug.LogWarning("DialogueManager: No dialogue data provided!");
            return;
        }

        currentDialogue = dialogue;
        currentLineIndex = 0;

        if (dialogueUI != null)
        {
            dialogueUI.SetActive(true);
        }

        DisplayNextLine();
    }

    /// <summary>
    /// Continues to the next line of dialogue or ends the dialogue if complete.
    /// </summary>
    public void ContinueDialogue()
    {
        if (currentDialogue == null)
        {
            Debug.LogWarning("DialogueManager: No dialogue to continue!");
            return;
        }

        if (currentLineIndex < currentDialogue.dialogueLines.Length - 1)
        {
            currentLineIndex++;
            DisplayNextLine();
        }
        else
        {
            EndDialogue();
        }
    }

    /// <summary>
    /// Displays the current line of dialogue.
    /// </summary>
    private void DisplayNextLine()
    {
        if (currentDialogue == null || currentDialogue.dialogueLines.Length == 0)
        {
            Debug.LogWarning("DialogueManager: Dialogue is empty or null!");
            EndDialogue();
            return;
        }

        var line = currentDialogue.dialogueLines[currentLineIndex];
        if (speakerText != null)
        {
            speakerText.text = line.speakerName;
        }

        if (dialogueText != null)
        {
            dialogueText.text = line.line;
        }
    }

    /// <summary>
    /// Ends the current dialogue sequence.
    /// </summary>
    public void EndDialogue()
    {
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false);
        }

        currentDialogue = null;
        currentLineIndex = 0;
    }
}
