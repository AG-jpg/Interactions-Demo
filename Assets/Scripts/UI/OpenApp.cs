using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApp : MonoBehaviour
{
    [SerializeField] public GameObject UIBox;
    public bool activeApp;

    private void Awake()
    {
        activeApp = false;
    }

    public void PressButton()
    {
        if(!activeApp)
        {
            OpenWindow();
        }
        else if(activeApp)
        {
            CloseWindow();
            return;
        }
    }

    public void OpenWindow()
    {
        activeApp = true;
        UIBox.SetActive(!UIBox.activeSelf);
    }

    public void CloseWindow()
    {
        activeApp = false;
        UIBox.SetActive(!UIBox.activeSelf);
    }
}