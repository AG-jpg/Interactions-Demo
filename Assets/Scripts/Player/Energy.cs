using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private float energyInitial;
    [SerializeField] private float energyMax;
    [SerializeField] private float regenXSecond;

    public float energyActual { get; private set; }
    void Start()
    {
        energyActual = energyInitial;
    }

    public void Useenergy(float cantidad)
    {
        if(energyActual >= cantidad)
        {
            energyActual -= cantidad;
        }
    }
}
