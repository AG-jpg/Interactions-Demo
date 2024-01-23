using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
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
    public bool battleWin;

    void Update()
    {
        if (signal01.hasGameFinished)
        {
            Destroy(puzzle01);
            Destroy(container01);
            Destroy(dialogue01);
            StartCoroutine(WaitingTime());
            dialogue02.SetActive(true);
        }

        if (signal02.hasGameFinished)
        {
            battleWin = true;
        }
    }

    private IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(1f);
    }
}
