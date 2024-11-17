using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    private Queue<string> sentences;
    [System.Serializable]
    public class Dialogue
    {
        public string npcName;
        [TextArea(3, 10)]
        public string[] sentences; // Array for multiple lines of dialogue.
    }

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false); // Hide dialogue box initially
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
        dialogueText.text = sentence; // Update UI text
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Debug.Log("End of Dialogue.");
    }
}
