using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Level _level;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Transform _edgePrefab;

    private bool hasGameFinished;
    private Cell[,] cells;
    private List<Vector2Int> filledPoints;
    private List<Transform> edges;
    private Vector2Int startPos, endPos;
    private List<Vector2Int> directions = new List<Vector2Int>()
    {
        Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
    };

    private void Awake()
    {
        Instance = this;
        hasGameFinished = false;
        filledPoints = new List<Vector2Int>();
        cells = new Cell[_level.Row, _level.Col];
        edges = new List<Transform>();
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = _level.Col * 0f;
        camPos.y = _level.Row * 0f;
        Camera.main.transform.position = camPos;
        Camera.main.orthographicSize = Mathf.Max(_level.Row, _level.Col) + 2f;

        for(int i=0; i < _level.Row; i++)
        {
            for(int j=0; j < _level.Col; j++)
            {
                cells[i,j] = Instantiate(_cellPrefab);
                cells[i,j].Init(_level.Data[i * _level.Col + j]);
                cells[i,j].transform.position = new Vector3(j + 0.5f, i + 0.5f, 0);
            }
        }
    }

    private void CheckWin()
    {
        for(int i=0; i < _level.Row; i++)
        {
            for(int j=0; j < _level.Col; j++)
            {
                if(!cells[i,j].Filled)
                    return;
            }
        }

        hasGameFinished = true;
        StartCoroutine(GameFinished());
    }

    private IEnumerator GameFinished()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
