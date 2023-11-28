using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    private UIManager uimanager;

    [Header("Quests")]
    [SerializeField] private Quest[] questDisponibles;

    [SerializeField] private Quest[] questTaken;

    [Header("Inspector Quests")]
    [SerializeField] private InspectorQuest inspectorQuestPrefab;
    [SerializeField] private Transform InpsectorQuestContainer;

    [Header("Player Quests")]
    [SerializeField] private PlayerQuest playerQuestPrefab;

    [SerializeField] private Transform playerQuestContainer;

    [Header("NPC Quests")]
    [SerializeField] private QuestContainer[] NPCquest;

    [SerializeField] private NPCManager NPCmanager;

    private Quest newquest;
    public string questName;

    public Quest questtoClaim { get; private set; }

    //Bools
    private bool ReadyforQuest;
    public bool QuestAccepted;

    public bool QuestClaim;

    private void Start()
    {
        questDisponibles = new Quest[questDisponibles.Length];
        QuestAccepted = false;
    }

    private void Update()
    {
        if(questDisponibles.Length <= 0)
        {
            ReadyforQuest = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) && ReadyforQuest == true)
        {
            LoadNPCQuest();
            LoadQuestInspector();
            ReadyforQuest = false;
        }

        ManageNPC();

        if (Input.GetKeyDown(KeyCode.V))
        {
            AddProgress("Fix You", 1);
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
                questName = newquest.Name;
            }
        }
    }

    private void ManageNPC()
    {
        if (QuestAccepted && questName == "Fix You")
        {
            NPCmanager.HideElla();
            NPCmanager.HideVM();
        }
        else if (QuestAccepted && questName == "Rock the Casbah")
        {
            NPCmanager.HideJohny();
        }
        else if (QuestAccepted && questName == "Looking For Water")
        {
            NPCmanager.HideGuard();
        }
    }

    //This rejects the quest in inspector
    public void ResetQuestList()
    {
        questDisponibles = new Quest[0];
        ReadyforQuest = true;
        QuestAccepted = false;
    }

    //This accepts the quest in inspector
    private void AddQuesttoComplete(Quest questToComplete)
    {
        PlayerQuest newQuest = Instantiate(playerQuestPrefab, playerQuestContainer);
        newQuest.ConfigureQuestUI(questToComplete);
        questDisponibles = new Quest[0];
        QuestAccepted = true;
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
        questTaken = questTaken.Append(questToComplete).ToArray();
    }

    public void AddProgress(string questID, int cantidad)
    {
        Quest questtoUpdate = QuestExist(questID);
        questtoUpdate.AddProgress(cantidad);
    }

//This Needs to be fixed! Array gets emptied after accepting!
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

    private void ShowCompletedQuest()
    {
        uimanager.ShowSuccesNotification();
    }

    private void QuestCompletedRespond(Quest questCompleted)
    {
        questtoClaim = QuestExist(questCompleted.ID);
        if(questCompleted.ID != null)
        {
            ShowCompletedQuest();
        }
    }

    private void OnEnable()
    {   
        Quest.EventQuestCompleted += QuestCompletedRespond;
    }

    private void OnDisable()
    {
        Quest.EventQuestCompleted -= QuestCompletedRespond;
    }
}