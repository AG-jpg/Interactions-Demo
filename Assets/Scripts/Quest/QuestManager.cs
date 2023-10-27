using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Quests")]
    [SerializeField] private Quest[] questDisponibles;

    [Header("Inspector Quests")]
    [SerializeField] private InspectorQuest inspectorQuestPrefab;
    [SerializeField] private Transform InpsectorQuestContainer;

    [Header("Player Quests")]
    [SerializeField] private PlayerQuest playerQuestPrefab;

    [SerializeField] private Transform playerQuestContainer;

    [Header("NPC Quests")]
    [SerializeField] private QuestContainer[] NPCquest;

    private Quest newquest;
    private bool ReadyforQuest;

    private void Start()
    {
        questDisponibles = new Quest[questDisponibles.Length];
        ReadyforQuest = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && ReadyforQuest == true)
        {
            LoadNPCQuest();
            LoadQuestInspector();
            ReadyforQuest = false;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            AddProgress("Rock the Casbah", 1);
        }
    }

    private void LoadQuestInspector()
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            QuestDescription newQuest = Instantiate(inspectorQuestPrefab, InpsectorQuestContainer);
            newQuest.ConfigureQuestUI(questDisponibles[i]);
        }
    }

    private void LoadNPCQuest()
    {
        for (int i = 0; i < NPCquest.Length; i++)
        {
            if (NPCquest[i].NPCActive == true)
            {
                newquest = NPCquest[i].Quests;
                questDisponibles = questDisponibles.Append(newquest).ToArray();
            }
        }
    }

    //This rejects the quest in inspector
    public void ResetQuestList()
    {
        questDisponibles = new Quest[0];
        ReadyforQuest = true;
    }

    //This accpets the quest in inspector
    private void AddQuesttoComplete(Quest questToComplete)
    {
        PlayerQuest newQuest = Instantiate(playerQuestPrefab, playerQuestContainer);
        newQuest.ConfigureQuestUI(questToComplete);
        questDisponibles = new Quest[0];
        ReadyforQuest = true;
        EraseQuestNPC();
    }

    private void EraseQuestNPC()
    {
        for (int i = 0; i < NPCquest.Length; i++)
        {
            if (NPCquest[i].NPCActive == true)
            {
                NPCquest[i].Quests = null;
            }
        }
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
            if (questDisponibles[i].ID == questID)
            {
                return questDisponibles[i];
            }
        }

        return null;
    }
}
