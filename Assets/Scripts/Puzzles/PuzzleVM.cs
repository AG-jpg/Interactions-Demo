using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleVM : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] public GameObject bg;

    [Header("Puzzle")]
    [SerializeField] private PuzzleGen puzzle;
    [SerializeField] private GameObject puzzleContainer;
    [SerializeField] private GameObject puzzleUI;
    public bool puzzleInitiated;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && puzzleInitiated == true)
        {
            puzzleContainer.SetActive(true);
            puzzleUI.SetActive(true);
            puzzle.CreateLevel();
            puzzle.SpawnLevel();
            puzzleInitiated = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleInitiated = true;
        }
    }
}
