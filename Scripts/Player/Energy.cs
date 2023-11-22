using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private float energyInitial;
    [SerializeField] private float energyMax;
    [SerializeField] private float regenXSecond;

    public float energyActual { get; private set; }
    public bool CanRestore => energyActual < energyMax;
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
}
