using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    private GameObject puzzleManager;
    private PuzzleManager puzzle;

    [Header("Quest bools")]
    public bool puzzleVM;
    public bool puzzleSecurity;
    public bool puzzleCage;

    private void Update()
    {
        puzzleManager = GameObject.Find("Puzzle Manager");
        puzzle = puzzleManager.GetComponent<PuzzleManager>();

        if (puzzle != null)
        {
            CheckPuzzle();
        }
    }

    public void CheckPuzzle()
    {
        if (puzzle.easySolved == true)
        {
            Player.Instance.LoadLocation();
            puzzle.easySolved = false;
            puzzleVM = true;
        }
        else if (puzzle.midSolved == true)
        {
            Player.Instance.LoadLocation();
            puzzle.midSolved = false;
            puzzleSecurity = true;
        }
        else if (puzzle.hardSolved == true)
        {
            Player.Instance.LoadLocation();
            puzzle.hardSolved = false;
            puzzleCage = true;
        }
    }
}