using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [Header("Ella")]
    [SerializeField] public GameObject Ella01;
    [SerializeField] public GameObject Ella02;

    public void HideElla()
    {
        Ella01.SetActive(false);
        Ella02.SetActive(true);
    }
}
