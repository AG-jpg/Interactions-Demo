using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header ("Quests")]
    [SerializeField] private Quest[] questDisponible;
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

    private void AddQuesttoFinish(Quest questtofinish)
    {
        PlayerQuest nuevoQuest = Instantiate(playerQuestPrefab, playerQuestContainer);
        nuevoQuest.ConfigureQuestUI(questtofinish);
    }

    public void AddQuest(Quest questtofinish)
    {
        AddQuesttoFinish(questtofinish);
    }
}
