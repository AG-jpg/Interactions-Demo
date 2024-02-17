using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{

    public static PuzzleManager instance;

    [Header("Puzzle Generator")]
    public GameObject puzzle;
    public PuzzleGen puzzleGen;
    private Scene scene;
    public string sceneName;
    public int sceneID;

    [Header("Bool")]
    public bool hasGameFinished;
    public bool introSolved;
    public bool easySolved;
    public bool midSolved;
    public bool hardSolved;
    public bool battleFinished;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        puzzle = GameObject.FindGameObjectWithTag("Puzzle");
        puzzleGen = puzzle.GetComponent<PuzzleGen>();
        hasGameFinished = puzzleGen.hasGameFinished;
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
            if (sceneName == "Puzzle Easy" && puzzleGen.hasGameFinished)
            {
                easySolved = true;
                StartCoroutine(GameFinished());
                puzzleGen.hasGameFinished = false;
            }
            else if (sceneName == "Puzzle Mid" && puzzleGen.hasGameFinished)
            {
                midSolved = true;
                StartCoroutine(GameFinished());
                puzzleGen.hasGameFinished = false;
            }
            else if (sceneName == "Puzzle Hard" && puzzleGen.hasGameFinished)
            {
                hardSolved = true;
                StartCoroutine(GameFinished());
                puzzleGen.hasGameFinished = false;
            }
            else if (sceneName == "Puzzle Battle" && puzzleGen.hasGameFinished)
            {
                battleFinished = true;
                StartCoroutine(GameFinished());
            }
            else if (sceneName == "Puzzle Intro" && puzzleGen.hasGameFinished)
            {
                introSolved = true;
                StartCoroutine(GameFinished());
            }
    }

    private IEnumerator GameFinished()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneID);
    }
}