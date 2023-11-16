using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        for(int i=0; i < _level.Row; i++)
        {
            for(int j=0; j < _level.Col; j++)
            {
                cells[i,j] = Instantiate(_cellPrefab);
                cells[i,j].Init(_level.Data[i * _level.Col + j]);
                cells[i,j].transform.position = new Vector3(j + 0f, i + 0f, 0);
            }
        }
    }

    private bool IsNeighbour()
    {
        return IsValid(startPos) && IsValid(endPos) && directions.Contains(startPos - endPos);
    }

    private bool IsValid(Vector2Int pos)
    {
        return pos.x >= 0 && pos.y >= 0 && pos.x < _level.Row && pos.y < _level.Col;
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
