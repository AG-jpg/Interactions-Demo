using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int numeroSlots;
    public int NumeroSlots => numeroSlots;

}
