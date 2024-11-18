using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Game/Quest")]
public class Quest : ScriptableObject
{
    public string questTitle;
    [TextArea] public string questDescription;
    public bool isQuestCompleted;

    // Optional: Add rewards, objectives, or other data as needed
    public int experienceReward;
    public string objective;
}