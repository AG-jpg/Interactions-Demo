using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] private int startCredits;
    public int TotalCredits { get; set; }
    private readonly string MONEY_KEY = "Money105020";

    private void Start()
    {
        AddCredits(startCredits);
        LoadMoney();
    }

    public void AddCredits(int cantidad)
    {
        TotalCredits += cantidad;
        SaveMoney();
    }

    public void RemoveCredits(int cantidad)
    {
        if (cantidad > TotalCredits)
        {
            return;
        }

        TotalCredits -= cantidad;
        SaveMoney();
    }

    #region Saving

    public MoneyData savedData;
    public void SaveMoney()
    {
        savedData = new MoneyData();
        savedData.creditsData = TotalCredits;

        SaveGame.Save(MONEY_KEY, savedData);
    }

    public MoneyData dataLoaded;
    public void LoadMoney()
    {
        if (SaveGame.Exists(MONEY_KEY))
        {
            dataLoaded = SaveGame.Load<MoneyData>(MONEY_KEY);
            TotalCredits = dataLoaded.creditsData;
        }
    }
    #endregion
}
