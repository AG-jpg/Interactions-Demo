using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [Header("Ella")]
    [SerializeField] public GameObject Ella01;
    [SerializeField] public GameObject Ella02;

    [Header("Johny")]
    [SerializeField] public GameObject Johny01;
    [SerializeField] public GameObject Johny02;

    [Header("Guard")]
    [SerializeField] public GameObject Guard01;
    [SerializeField] public GameObject Guard02;

    [Header("VendingMachine")]
    [SerializeField] public GameObject VM01;
    [SerializeField] public GameObject VM02;
    [SerializeField] public GameObject VM03;

    public void HideElla()
    {
        Ella01.SetActive(false);
        Ella02.SetActive(true);
    }

    public void HideJohny()
    {
        Johny01.SetActive(false);
        Johny02.SetActive(true);
    }

    public void HideGuard()
    {
        Guard01.SetActive(false);
        Guard02.SetActive(true);
    }

    public void HideVM()
    {
        VM01.SetActive(false);
        VM02.SetActive(true);
    }

    public void VMFInal()
    {
        VM02.SetActive(false);
        VM03.SetActive(true);
    }
}
