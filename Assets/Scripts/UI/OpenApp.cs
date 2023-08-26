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
        }
    }

    public void OpenWindow()
    {
        activeApp = true;
        UIBox.SetActive(true);
    }

    public void CloseWindow()
    {
        activeApp = false;
        UIBox.SetActive(false);
    }
}
