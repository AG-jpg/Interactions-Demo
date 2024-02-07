using System.Linq;
using TMPro;
using BayatGames.SaveGameFree;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Player")]
    [SerializeField] private Player player;

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
        questDisponibles = new Quest[questDisponibles.Length];
        QuestAccepted = false;
        messagesRead = false;
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
        BreakFree();
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
            NPCManager.Instance.HideElla();
            NPCManager.Instance.HideVM();
        }
        else if (QuestAccepted && questName == "I Want To Break Free")
        {
            NPCManager.Instance.HideJohny();
            NPCManager.Instance.StartMainQuest();
        }
        else if (QuestAccepted && questName == "Looking For Water")
        {
            NPCManager.Instance.HideGuard();
        }
        else if (QuestAccepted && questName == "Somebody Told Me")
        {
            NPCManager.Instance.HideJr();
            NPCManager.Instance.ShowMessage();
        }
        else if(GameManager.Instance.puzzleBattle)
        {
            GameManager.Instance.AfterBattle();
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
        questTaken = questTaken.Append(questToComplete).ToArray();
        QuestAccepted = true;
        SaveQuestData();
        questDisponibles = new Quest[0];
        questToComplete.questTaken = true;
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
        GameManager.Instance.SaveMyGame();
        SaveQuestData();
    }

    public void AddQuest(Quest questToComplete)
    {
        AddQuesttoComplete(questToComplete);
        //questTaken = questTaken.Append(questToComplete).ToArray();
        SaveQuestData();
    }

    public void AddProgress(string questID, int cantidad)
    {
        Quest questtoUpdate = QuestExist(questID);
        questtoUpdate.AddProgress(cantidad);
        SaveQuestData();
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

    private void BreakFree()
    {
        if (GameManager.Instance.puzzleSecurity)
        {
            AddProgress("I Want To Break Free", 1);
            UIManager.Instance.DoorsNotification();
            ClaimReward();
            GameManager.Instance.puzzleSecurity = false;
            GameManager.Instance.SaveMyGame();
        }

        if (GameManager.Instance.puzzleCage)
        {
            AddProgress("I Want To Break Free", 1);
            ClaimReward();
            GameManager.Instance.puzzleCage = false;
            GameManager.Instance.SaveMyGame();
        }
    }

    private void FixYou()
    {
        if (GameManager.Instance.puzzleVM)
        {
            AddProgress("Fix You", 1);
            ClaimReward();
            NPCManager.Instance.VMFInal();
            NPCManager.Instance.HideZimanGuard();
            GameManager.Instance.puzzleVM = false;
            GameManager.Instance.SaveMyGame();
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
                NPCManager.Instance.FinalGuard();
                NPCManager.Instance.VMAfter();
                UIManager.Instance.CloseGiveAway();
                InventoryUI.Instance.itemGiven = false;
                GameManager.Instance.SaveMyGame();
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
            messagesRead = false;
            ComputerInteract.Instance.readingMessage = false;
            ClaimReward();
            GameManager.Instance.SaveMyGame();
        }
    }

    #endregion

    #region Saving

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
        savedData.questsData = new Quest[questTaken.Length];
        savedData.idData = new string[questTaken.Length];
        savedData.cantidadObjetivoData = new int[questTaken.Length];
        savedData.cantidadActualData = new int[questTaken.Length];

        for (int i = 0; i < questTaken.Length; i++)
        {
            if (questTaken[i] == null || string.IsNullOrEmpty(questTaken[i].ID))
            {
                savedData.idData[i] = null;
                savedData.cantidadObjetivoData[i] = 0;
                savedData.cantidadActualData[i] = 0;
            }
            else
            {
                savedData.questsData = questTaken;
                savedData.idData[i] = questTaken[i].ID;
                savedData.cantidadObjetivoData[i] = questTaken[i].CantidadObjetivo;
                savedData.cantidadActualData[i] = questTaken[i].cantidadActual;
            }
        }

        SaveGame.Save(QUEST_KEY, savedData);
    }

    public QuestData dataLoaded;
    public void LoadQuestData()
    {
        if (SaveGame.Exists(QUEST_KEY))
        {
            dataLoaded = SaveGame.Load<QuestData>(QUEST_KEY);
            for (int i = 0; i < dataLoaded.questsData.Length; i++)
            {
                if (dataLoaded.idData != null)
                {
                    Quest questStored = QuestExistsinSaved(dataLoaded.idData[i]);
                    if (questStored != null)
                    {
                        questTaken = dataLoaded.questsData;
                        AddQuesttoComplete(dataLoaded.questsData[i]);
                        AddProgress(dataLoaded.questsData[i].ID, dataLoaded.questsData[i].cantidadActual);
                        questName = dataLoaded.questsData[i].ID;
                        ManageNPC();
                    }
                }
                else
                {
                    questTaken = null;
                }
            }
        }
    }

    #endregion
}