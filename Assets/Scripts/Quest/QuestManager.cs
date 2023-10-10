using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header ("Quests")]
    [SerializeField] private Quest[] questDisponibles;

    [Header ("Inspector Quest Quests")]
    [SerializeField] private InspectorQuest inspectorQuestPrefab;
    [SerializeField] private Transform InpsectorQuestContainer;

    [Header ("Player Quests")]
    [SerializeField] private PlayerQuest playerQuestPrefab;

    [SerializeField] private Transform playerQuestContainer;

    void Start()
    {
        LoadQuestInspector();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            AddProgress("Rock the Casbah", 1);
            //AddProgress("Looking for Water", 1);
        }
    }

    private void LoadQuestInspector()
    {
        for(int i=0; i < questDisponibles.Length; i++)
        {
            QuestDescription newQuest = Instantiate(inspectorQuestPrefab, InpsectorQuestContainer);
            newQuest.ConfigureQuestUI(questDisponibles[i]);
        }
    }

    private void AddQuesttoComplete(Quest questToComplete)
    {
        PlayerQuest newQuest = Instantiate(playerQuestPrefab, playerQuestContainer);
        newQuest.ConfigureQuestUI(questToComplete);
    }

    public void AddQuest(Quest questToComplete)
    {
        AddQuesttoComplete(questToComplete);
    }

    public void AddProgress(string questID, int cantidad)
    {
        Quest questtoUpdate = QuestExist(questID);
        questtoUpdate.AddProgress(cantidad);
    }

    private Quest QuestExist(string questID)
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            if(questDisponibles[i].ID == questID)
            {
                return questDisponibles[i];
            }
        }

        return null;
    }
}
