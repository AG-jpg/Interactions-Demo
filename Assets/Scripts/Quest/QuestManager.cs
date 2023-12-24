using System.Linq;
using TMPro;
using BayatGames.SaveGameFree;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Player")]
    [SerializeField] private Player player;
    [SerializeField] private Menu menu;

    [Header("Quests")]
    [SerializeField] private Quest[] questDisponibles;
    [SerializeField] private QuestStorage storage;

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
    [HideInInspector] public string questName;

    public Quest questtoClaim { get; private set; }

    [Header("Bools")]
    [HideInInspector] private bool ReadyforQuest;
    [HideInInspector] public bool QuestAccepted;
    [HideInInspector] public bool messagesRead;
    [HideInInspector] public bool QuestClaim;

    [Header("Key")]
    private readonly string QUEST_KEY = "Quest105020";

    private void Start()
    {
        //SaveGame.DeleteAll(); //Erase Saved Data
        questDisponibles = new Quest[questDisponibles.Length];
        QuestAccepted = false;
        //LoadQuestData();
    }

    private void Update()
    {
        if (questDisponibles.Length <= 0)
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

        //Quest List
        FixYou();
        LookigForWater();
        SomebodyToldMe();
        RockCasbah();
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
        else if (QuestAccepted && questName == "Somebody Told Me")
        {
            NPCmanager.HideJr();
            NPCmanager.ShowMessage();
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

    public void ClaimReward()
    {
        if (questtoClaim == null)
        {
            return;
        }

        MoneyManager.Instance.AddCredits(questtoClaim.Credits);
        player.Experience.AddExp(questtoClaim.Experience);
        questtoClaim = null;
    }

    public void AddQuest(Quest questToComplete)
    {
        AddQuesttoComplete(questToComplete);
        questTaken = questTaken.Append(questToComplete).ToArray();
        //SaveQuestData();
    }

    public void AddProgress(string questID, int cantidad)
    {
        Quest questtoUpdate = QuestExist(questID);
        questtoUpdate.AddProgress(cantidad);
        //SaveQuestData();
    }

    //This Needs to be fixed! Array gets emptied after accepting!
    private Quest QuestExist(string questID)
    {
        for (int i = 0; i < questTaken.Length; i++)
        {
            if (questTaken[i].ID == questID)
            {
                return questTaken[i];
            }
        }

        return null;
    }

    private void ShowCompletedQuest()
    {
        UIManager.Instance.ShowSuccesNotification();
    }

    private void QuestCompletedRespond(Quest questCompleted)
    {
        questtoClaim = QuestExist(questCompleted.ID);
        if (questCompleted.ID != null)
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

    #region Quests

    private void RockCasbah()
    {
        if (GameManager.Instance.puzzleSecurity)
        {
            AddProgress("Rock the Casbah", 1);
            NPCmanager.HideRedDoors();
            UIManager.Instance.DoorsNotification();
            ClaimReward();
            GameManager.Instance.puzzleSecurity = false;
        }

        if (GameManager.Instance.puzzleCage)
        {
            AddProgress("Rock the Casbah", 1);
            NPCmanager.HideAnimals();
            NPCmanager.HideKatai();
            UIManager.Instance.DoorsNotification();
            ClaimReward();
            GameManager.Instance.puzzleCage = false;
        }
    }

    private void FixYou()
    {
        if (GameManager.Instance.puzzleVM)
        {
            AddProgress("Fix You", 1);
            ClaimReward();
            NPCmanager.VMFInal();
            NPCmanager.HideZimanGuard();
            GameManager.Instance.puzzleVM = false;
        }
    }

    private void LookigForWater()
    {
        if (InventoryUI.Instance.itemID == "Bottled Water")
        {
            if (InventoryUI.Instance.itemGiven == true)
            {
                AddProgress("Looking For Water", 1);
                ClaimReward();
                NPCmanager.FinalGuard();
                NPCmanager.VMAfter();
                UIManager.Instance.CloseAllPanels();
                InventoryUI.Instance.itemGiven = false;
            }
        }
        else
        {
            InventoryUI.Instance.itemGiven = false;
        }
    }

    private void SomebodyToldMe()
    {
        if (messagesRead)
        {
            AddProgress("Somebody Told Me", 1);
            ClaimReward();
            messagesRead = false;
        }
    }

    #endregion

    private Quest QuestExistsinSaved(string ID)
    {
        for (int i = 0; i < storage.Quests.Length; i++)
        {
            if (storage.Quests[i].ID == ID)
            {
                return storage.Quests[i];
            }
        }

        return null;
    }

    public QuestData savedData;
    public void SaveQuestData()
    {
        savedData = new QuestData();
        savedData.idData = new string[0];
        savedData.cantidadData = new int[0];
        savedData.cantidadActualData = new int[0];

        SaveGame.Save(QUEST_KEY, savedData);
    }
}