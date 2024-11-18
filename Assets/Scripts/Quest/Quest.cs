using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Game/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    [TextArea(3, 10)]
    public string description;
    public bool isCompleted;
    public Dialog questDialog; // Dialog shown during/after the quest
}