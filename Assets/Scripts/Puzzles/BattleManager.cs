using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [Header("Puzzles")]
    [SerializeField] public GameObject puzzle01;
    [SerializeField] public GameObject puzzle02;
    [SerializeField] public PuzzleGen signal01;
    [SerializeField] public PuzzleGen signal02;

    [Header("Dialogues")]
    [SerializeField] public GameObject dialogue01;
    [SerializeField] public GameObject dialogue02;

    [Header("Containers")]
    [SerializeField] public GameObject container01;

    [SerializeField] private int sceneID;

    void Update()
    {
        if (signal01.hasGameFinished)
        {
            Destroy(puzzle01);
            Destroy(container01);
            Destroy(dialogue01);
            StartCoroutine(WaitingTime());
        }

        if (signal02.hasGameFinished)
        {
            SceneManager.LoadScene(sceneID);
        }
    }

    private IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(1f);
        dialogue02.SetActive(true);
    }
}
