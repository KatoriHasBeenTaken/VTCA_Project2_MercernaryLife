using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Quest> activeQuests = new List<Quest>();

    public void AddQuest(Quest newQuest)
    {
        activeQuests.Add(newQuest);
        Debug.Log("Quest Added: " + newQuest.questName);
    }
    [System.Serializable]
    public class Quest
    {
        public string questName;
        public string description;
        public bool isCompleted;
    }
}
