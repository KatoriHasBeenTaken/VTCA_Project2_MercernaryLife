using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private List<Quest> activeQuests = new List<Quest>();
    private List<Quest> completedQuests = new List<Quest>();

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
        }
    }

    /// <summary>
    /// Adds a new quest to the active quest list.
    /// </summary>
    /// <param name="quest">The quest to add.</param>
    public void AddQuest(Quest quest)
    {
        if (quest == null)
        {
            Debug.LogWarning("QuestManager: Attempted to add a null quest.");
            return;
        }

        if (activeQuests.Contains(quest))
        {
            Debug.LogWarning($"QuestManager: Quest '{quest.questTitle}' is already active.");
            return;
        }

        if (quest.isQuestCompleted)
        {
            Debug.LogWarning($"QuestManager: Quest '{quest.questTitle}' is already completed.");
            return;
        }

        activeQuests.Add(quest);
        Debug.Log($"QuestManager: Quest '{quest.questTitle}' added to active quests.");
    }

    /// <summary>
    /// Marks a quest as completed, moves it to the completed quest list.
    /// </summary>
    /// <param name="quest">The quest to complete.</param>
    public void CompleteQuest(Quest quest)
    {
        if (quest == null)
        {
            Debug.LogWarning("QuestManager: Attempted to complete a null quest.");
            return;
        }

        if (!activeQuests.Contains(quest))
        {
            Debug.LogWarning($"QuestManager: Quest '{quest.questTitle}' is not in the active quest list.");
            return;
        }

        activeQuests.Remove(quest);
        completedQuests.Add(quest);
        quest.isQuestCompleted = true;

        Debug.Log($"QuestManager: Quest '{quest.questTitle}' marked as completed.");
    }

    /// <summary>
    /// Gets the list of active quests.
    /// </summary>
    /// <returns>A list of active quests.</returns>
    public List<Quest> GetActiveQuests()
    {
        return new List<Quest>(activeQuests); // Return a copy to prevent external modification
    }

    /// <summary>
    /// Gets the list of completed quests.
    /// </summary>
    /// <returns>A list of completed quests.</returns>
    public List<Quest> GetCompletedQuests()
    {
        return new List<Quest>(completedQuests); // Return a copy to prevent external modification
    }

    /// <summary>
    /// Checks if a specific quest is currently active.
    /// </summary>
    /// <param name="quest">The quest to check.</param>
    /// <returns>True if the quest is active; otherwise, false.</returns>
    public bool IsQuestActive(Quest quest)
    {
        return activeQuests.Contains(quest);
    }

    /// <summary>
    /// Checks if a specific quest has been completed.
    /// </summary>
    /// <param name="quest">The quest to check.</param>
    /// <returns>True if the quest is completed; otherwise, false.</returns>
    public bool IsQuestCompleted(Quest quest)
    {
        return completedQuests.Contains(quest);
    }
}
