using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{

    public static PuzzleManager instance;

    [Header("Puzzle Generator")]
    private GameObject puzzle;
    private PuzzleGen puzzleGen;
    private Scene scene;
    public string sceneName;
    public int sceneID;

    [Header("Bool")]
    public bool easySolved;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        puzzle = GameObject.FindGameObjectWithTag("Puzzle");
        puzzleGen = puzzle.GetComponent<PuzzleGen>();
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    private void Update()
    {
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
    }

    private IEnumerator GameFinished()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneID);
    }
}
