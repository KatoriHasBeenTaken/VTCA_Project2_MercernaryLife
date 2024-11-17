using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : ScriptableObject
{
    [System.Serializable]
    public class Dialogue
    {
        public string npcName;
        [TextArea(3, 10)]
        public string[] sentences; // Array for multiple lines of dialogue.
    }
}
