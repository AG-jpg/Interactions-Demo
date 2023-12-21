using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    [SerializeField] private Player player;
    private GameObject puzzleManager;
    private PuzzleManager puzzle;

    [Header("Positions")]
    [SerializeField] public GameObject VMmachine;
    [SerializeField] public GameObject securitySystem;
    [SerializeField] public GameObject cageSystem;

    private void Update()
    {
        puzzleManager = GameObject.Find("Puzzle Manager");
        puzzle = puzzleManager.GetComponent<PuzzleManager>();
        CheckPosition();
    }

    public void CheckPosition()
    {
        if(puzzle.easySolved == true)
        {
            player.transform.position = VMmachine.transform.position;
            puzzle.easySolved = false;
        }
        else if(puzzle.midSolved == true)
        {
            player.transform.position = securitySystem.transform.position;
            puzzle.midSolved = false;
        }
        else if(puzzle.hardSolved == true)
        {
            player.transform.position = cageSystem.transform.position;
            puzzle.hardSolved = false;
        }
    }
}