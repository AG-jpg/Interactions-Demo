using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : Singleton<NPCManager>
{
    public SoundManager soundManager;

    [Header("Ella")]
    [SerializeField] public GameObject Ella00;
    [SerializeField] public GameObject Ella01;
    [SerializeField] public GameObject Ella02;

    [Header("Johny")]
    [SerializeField] public GameObject Johny01;
    [SerializeField] public GameObject Johny02;

    [Header("Guard")]
    [SerializeField] public GameObject Guard00;
    [SerializeField] public GameObject Guard01;
    [SerializeField] public GameObject Guard02;
    [SerializeField] public GameObject Guard03;
    [SerializeField] public GameObject Guardziman;
    [SerializeField] public GameObject Guardzimansecond;

    [Header("VendingMachine")]
    [SerializeField] public GameObject VM01;
    [SerializeField] public GameObject VM02;
    [SerializeField] public GameObject VM03;
    [SerializeField] public GameObject VM04;

    [Header("Jr. Scientist")]
    [SerializeField] public GameObject Jr01;
    [SerializeField] public GameObject Jr02;

    [Header("Dr. Katai")]
    [SerializeField] public GameObject Katai01;
    [SerializeField] public GameObject Katai02;
    [SerializeField] public GameObject Katai03;

    //Objects

    [Header("Red Doors")]
    [SerializeField] public GameObject redDoors;

    [Header("Animals")]
    [SerializeField] public GameObject animals;

    [Header("Messages")]
    [SerializeField] public GameObject messages;

    [Header("Smoke")]
    [SerializeField] public GameObject smoke;    

    public void StartMainQuest()
    {
        Destroy(Ella00);
        Destroy(Guard00);
        Ella01.SetActive(true);
        Guard01.SetActive(true);
    }

    public void HideElla()
    {
        Destroy(Ella01);
        Ella02.SetActive(true);
    }

    public void HideJohny()
    {
        Destroy(Johny01);
        Johny02.SetActive(true);
    }

    public void HideGuard()
    {
        Destroy(Guard01);
        Guard02.SetActive(true);
    }

    public void HideZimanGuard()
    {
        Guardziman.SetActive(false);
        Guardzimansecond.SetActive(true);
    }

    public void HideVM()
    {
        Destroy(VM01);
        VM02.SetActive(true);
    }

    public void HideJr()
    {
        Destroy(Jr01);
        Jr02.SetActive(true);
    }

    public void HideKatai()
    {
        Katai02.SetActive(true);
    }

    public void HideRedDoors()
    {
        Destroy(redDoors);
    }

    public void HideAnimals()
    {
        Destroy(animals);
    }

    public void ShowMessage()
    {
        messages.SetActive(true);
    }

    //Final Dialogues
    public void VMFInal()
    {
        Destroy(VM02);
        VM03.SetActive(true);
    }

    public void VMAfter()
    {
        Destroy(VM03);
        VM04.SetActive(true);
    }

    public void FinalGuard()
    {
        Destroy(Guard02);
        Guard03.SetActive(true);
    }

    public void DestroyMessages()
    {
        Destroy(messages);
    }

    public void FinalMission()
    {
        Destroy(Katai01);
        Destroy(Katai02);
        Katai03.SetActive(true);
        smoke.SetActive(true);
    }
}
