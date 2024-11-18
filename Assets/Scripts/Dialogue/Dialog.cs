using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName; // Name of the NPC or player
        [TextArea] public string line; // Dialogue line text
    }

    public DialogueLine[] dialogueLines;
}
