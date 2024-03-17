using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    private GameObject puzzleManager;
    private PuzzleManager puzzle;
    [SerializeField] public GameObject spot;
    [SerializeField] public GameObject fade;

    [Header("Puzzle Computers")]
    [SerializeField] public GameObject Pzzl00;
    [SerializeField] public GameObject Pzzl01;
    [SerializeField] public GameObject Pzzl02;

    [Header("Quest bools")]
    public bool puzzleIntro;
    public bool puzzleTrain;
    public bool puzzleVM;
    public bool puzzleSecurity;
    public bool puzzleCage;
    public bool puzzleBattle;
    public bool endTrip;

    [SerializeField] public GameObject battleDialogue;
    private readonly string GAME_KEY = "Game105020";

    private void Start()
    {
        //SaveGame.DeleteAll(); //Erase Saved Data
        LoadSavedGame();
        Player.Instance.SaveLocation();

        if (puzzleTrain)
        {
            NPCManager.Instance.ShowTrainRide();
            Player.instance.transform.position = spot.transform.position;
            SoundManager.Instance.PlayCity();
            endTrip = true;
            puzzleTrain = false;
            SaveMyGame();
        }
    }

    private void Update()
    {
        puzzleManager = GameObject.Find("Puzzle Manager");
        puzzle = puzzleManager.GetComponent<PuzzleManager>();

        CheckPuzzle();
    }

    public void CheckPuzzle()
    {
        if (puzzle.introSolved == true)
        {
            puzzleIntro = true;
            SaveBools();
            Player.Instance.LoadLocation();
            UIManager.Instance.CloseEmail();
            Destroy(puzzleManager);
        }

        if (puzzle.trainSolved == true)
        {
            puzzleTrain = true;
            NPCManager.Instance.TicketsFinal();
            NPCManager.Instance.ShowTrainRide();
            Player.instance.transform.position = spot.transform.position;
            SoundManager.Instance.PlayCity();
            Destroy(puzzleManager);
            endTrip = true;
            puzzle.trainSolved = false;
            SaveBools();
            SaveMyGame();
        }

        if (puzzle.easySolved == true)
        {
            puzzleTrain = false;
            Player.Instance.LoadLocation();
            UIManager.Instance.CloseEmail();
            SoundManager.Instance.PlayCity();
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
            UIManager.Instance.CloseEmail();
            SoundManager.Instance.PlayLab();
            puzzleSecurity = true;
            puzzleTrain = false;
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
            UIManager.Instance.CloseEmail();
            SoundManager.Instance.PlayLab();
            puzzleCage = true;
            puzzleTrain = false;
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
            fade.SetActive(true);
            StartCoroutine(Fades());
            Player.Instance.LoadLocation();
            UIManager.Instance.CloseEmail();
            puzzleBattle = true;
            puzzleTrain = false;
            SaveBools();
        }
    }

    public void AfterIntro()
    {
        UIManager.Instance.CloseEmail();
        NPCManager.Instance.HideBoss();
        NPCManager.Instance.OutofOffice();
        NPCManager.Instance.ShowHintOut();
        Destroy(Pzzl00);
    }
    public void AfterBattle()
    {
        Destroy(Pzzl01);
        Destroy(Pzzl02);
        UIManager.Instance.CloseEmail();
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

    private IEnumerator Fades()
    {
        yield return new WaitForSeconds(1.5f);
        fade.SetActive(false);
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
        savedData.introData = puzzleIntro;
        savedData.trainData = puzzleTrain;

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
            puzzleIntro = dataLoaded.introData;
            puzzleTrain = dataLoaded.trainData;
        }
    }

    #endregion
}