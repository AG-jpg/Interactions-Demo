using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header ("Quests")]
    [SerializeField] private Quest[] questDisponible;

    [Header ("Inspector Quest Quests")]
    [SerializeField] private QuestDescription inspectorQuestPrefab;
    [SerializeField] private Transform InpsectorQuestContainer;

    [Header ("Player Quests")]
    [SerializeField] private PlayerQuest playerQuestPrefab;

    [SerializeField] private Transform playerQuestContainer;

    void Start()
    {
        LoadQuestInspector();
    }

    private void LoadQuestInspector()
    {
        for(int i=0; i < questDisponible.Length; i++)
        {
            QuestDescription newQuest = Instantiate(inspectorQuestPrefab, InpsectorQuestContainer);
            newQuest.ConfigureQuestUI(questDisponible[i]);
        }
    }

    private void AddQuesttoComplete(Quest questtocomplete)
    {
        PlayerQuest newQuest = Instantiate(playerQuestPrefab, playerQuestContainer);
        newQuest.ConfigureQuestUI(questtocomplete);
    }

    public void AddQuest(Quest questtocomplete)
    {
        AddQuesttoComplete(questtocomplete);
    }

    public void AddProgress(string questID, int cantidad)
    {
        Quest questtoUpdate = QuestExist(questID);
        questtoUpdate.AddProgress(cantidad);
    }

    public Quest QuestExist(string questID)
    {
        for (int i = 0; i < questDisponible.Length; i++)
        {
            if(questDisponible[i].ID == questID)
            {
                return questDisponible[i];
            }
        }

        return null;
    }
}
