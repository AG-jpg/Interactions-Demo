using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] private int startCredits;
    public int TotalCredits { get; set; }
    private string KEY_CREDITS = "MYGAME_CREDITS";

    private void Start()
    {
        TotalCredits += startCredits;
        LoadCredits();
    }

    private void LoadCredits()
    {
        TotalCredits = PlayerPrefs.GetInt(KEY_CREDITS);
    }

    public void AddCredits(int cantidad)
    {
        TotalCredits += cantidad;
        PlayerPrefs.SetInt(KEY_CREDITS, TotalCredits);
        PlayerPrefs.Save();
    }

    public void RemoveCredits(int cantidad)
    {
        if(cantidad > TotalCredits)
        {
            return;
        }

        TotalCredits -= cantidad;
        PlayerPrefs.SetInt(KEY_CREDITS, TotalCredits);
        PlayerPrefs.Save();
    }
}
