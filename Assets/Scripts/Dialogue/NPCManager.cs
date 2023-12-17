using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public SoundManager soundManager;

    [Header("Ella")]
    [SerializeField] public GameObject Ella01;
    [SerializeField] public GameObject Ella02;

    [Header("Johny")]
    [SerializeField] public GameObject Johny01;
    [SerializeField] public GameObject Johny02;

    [Header("Guard")]
    [SerializeField] public GameObject Guard01;
    [SerializeField] public GameObject Guard02;
    [SerializeField] public GameObject Guard03;
    [SerializeField] public GameObject Guardziman;
    [SerializeField] public GameObject Guardzimansecond;

    [Header("VendingMachine")]
    [SerializeField] public GameObject VM01;
    [SerializeField] public GameObject VM02;
    [SerializeField] public GameObject VM03;

    [Header("Jr. Scientist")]
    [SerializeField] public GameObject Jr01;
    [SerializeField] public GameObject Jr02;

    [Header("Red Doors")]
    [SerializeField] public GameObject redDoors;
    [Header("Messages")]
    [SerializeField] public GameObject messages;

    private void Awake()
    {
        messages.SetActive(false);
    }
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

    public void HideZimanGuard()
    {
        Guardziman.SetActive(false);
        Guardzimansecond.SetActive(true);
    }

    public void HideVM()
    {
        VM01.SetActive(false);
        VM02.SetActive(true);
    }

    public void HideJr()
    {
        Jr01.SetActive(false);
        Jr02.SetActive(true);
    }

    public void HideRedDoors()
    {
        redDoors.SetActive(false);
    }

    public void ShowMessage()
    {
        messages.SetActive(true);
    }

    //Final Dialogues
    public void VMFInal()
    {
        VM02.SetActive(false);
        VM03.SetActive(true);
    }

    public void FinalGuard()
    {
        Guard02.SetActive(false);
        Guard03.SetActive(true);
    }
}
