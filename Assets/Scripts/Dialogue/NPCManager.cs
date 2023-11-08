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
}
