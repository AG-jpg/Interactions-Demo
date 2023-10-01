using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header ("Quests")]
    [SerializeField] private Quest[] questDisponible;
    [SerializeField] private QuestDescription inspectorQuestPrefab;
    [SerializeField] private Transform InpsectorQuestContainer;

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
}
