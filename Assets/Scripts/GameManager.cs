using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    private GameObject puzzleManager;
    private PuzzleManager puzzle;

    [Header("Puzzle Computers")]
    [SerializeField] public GameObject Pzzl01;
    [SerializeField] public GameObject Pzzl02;

    [Header("Quest bools")]
    public bool puzzleVM;
    public bool puzzleSecurity;
    public bool puzzleCage;
    public bool puzzleBattle;

    [SerializeField] public GameObject battleDialogue;
    private readonly string GAME_KEY = "Game105020";

    private void Start()
    {
        SaveGame.DeleteAll(); //Erase Saved Data
        LoadSavedGame();
    }

    private void Update()
    {
        puzzleManager = GameObject.Find("Puzzle Manager");
        puzzle = puzzleManager.GetComponent<PuzzleManager>();

        CheckPuzzle();
    }

    public void CheckPuzzle()
    {
        if (puzzle.easySolved == true)
        {
            Player.Instance.LoadLocation();
            puzzleVM = true;
            SaveBools();
            //puzzle.easySolved = false;
            Destroy(puzzleManager);
            NPCManager.Instance.VMFInal();
            NPCManager.Instance.HideZimanGuard();
        }

        if (puzzle.midSolved == true)
        {
            Player.Instance.LoadLocation();
            puzzleSecurity = true;
            SaveBools();
            //puzzle.midSolved = false;
            Destroy(puzzleManager);
            NPCManager.Instance.HideRedDoors();
            NPCManager.Instance.FinalGuard();
            NPCManager.Instance.VMAfter();
            Destroy(Pzzl01);
        }

        if (puzzle.hardSolved == true)
        {
            Player.Instance.LoadLocation();
            puzzleCage = true;
            SaveBools();
            //puzzle.hardSolved = false;
            Destroy(puzzleManager);
            NPCManager.Instance.FinalGuard();
            NPCManager.Instance.VMAfter();
            NPCManager.Instance.HideAnimals();
            NPCManager.Instance.HideKatai();
            NPCManager.Instance.DestroyMessages();
            NPCManager.Instance.HideRedDoors();
            Destroy(Pzzl01);
            Destroy(Pzzl02);
            battleDialogue.SetActive(true);
        }

        if (puzzle.battleFinished == true)
        {
            Player.Instance.LoadLocation();
            puzzleBattle = true;
            SaveBools();
        }
    }

    public void AfterBattle()
    {
        Destroy(Pzzl01);
        Destroy(Pzzl02);
        NPCManager.Instance.FinalMission();
        NPCManager.Instance.ToEnding();
        Destroy(puzzleManager);
    }

    public void SaveMyGame()
    {
        Player.Instance.SaveLocation();
        QuestManager.Instance.SaveQuestData();
        Inventory.Instance.SaveInventory();
        Energy.Instance.SaveEnergy();
        MoneyManager.Instance.SaveMoney();
        Experience.Instance.SaveStats();
        SaveBools();
        StartCoroutine(WaitingTime());
    }

    public void LoadSavedGame()
    {
        Player.Instance.LoadLocation();
        QuestManager.Instance.LoadQuestData();
        Inventory.Instance.LoadInventory();
        Energy.Instance.LoadEnergy();
        MoneyManager.Instance.LoadMoney();
        Experience.Instance.LoadStats();
        LoadBools();
    }

    private IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(4f);
        UIManager.Instance.SavedNotification();
    }

    #region Saving

    public GameData savedData;
    public void SaveBools()
    {
        savedData = new GameData();
        savedData.vmData = puzzleVM;
        savedData.securityData = puzzleSecurity;
        savedData.cageData = puzzleCage;
        savedData.battleData = puzzleBattle;

        SaveGame.Save(GAME_KEY, savedData);
    }

    public GameData dataLoaded;
    public void LoadBools()
    {
        if (SaveGame.Exists(GAME_KEY))
        {
            dataLoaded = SaveGame.Load<GameData>(GAME_KEY);
            puzzleVM = dataLoaded.vmData;
            puzzleSecurity = dataLoaded.securityData;
            puzzleCage = dataLoaded.cageData;
            puzzleBattle = dataLoaded.battleData;
        }
    }

    #endregion
}