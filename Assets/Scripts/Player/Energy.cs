using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private float energyInitial;
    [SerializeField] private float energyMax;
    [SerializeField] private float regenXSecond;

    public float energyActual { get; private set; }
    public bool CanRestore => energyActual < energyMax;
    private readonly string ENERGY_KEY = "Energy105020";

    void Start()
    {
        energyActual = energyInitial;
        UpdateEnergyBar();

        InvokeRepeating(nameof(GetEnergy), 1, 1);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Useenergy(5f);
        }
    }
    public void Useenergy(float cantidad)
    {
        if(energyActual >= cantidad)
        {
            energyActual -= cantidad;
            UpdateEnergyBar();
            SaveEnergy();
        }
    }

    public void RestoreEnergy(float cantidad)
    {
        if(energyActual >= energyMax)
        {
            return;
        }

        energyActual += cantidad;
        if(energyActual > energyMax)
        {
            energyActual = energyMax;
        }

        UIManager.Instance.UpdateEnergyPlayer(energyActual, energyMax);
        SaveEnergy();
    }

    private void GetEnergy()
    {
        energyActual += regenXSecond;
        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        UIManager.Instance.UpdateEnergyPlayer(energyActual, energyMax);
    }

    #region Saving

    public EnergyData savedData;
    private void SaveEnergy()
    {
        savedData = new EnergyData();
        savedData.energyData = energyActual;

        SaveGame.Save(ENERGY_KEY, savedData);
    }

    #endregion
}
