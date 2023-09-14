using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Slot slotPrefab;
    [SerializeField] private Transform container;

    private List<Slot> slotsDisponibles = new List<Slot>();

    void Start()
    {
        InicializarInventario();
    }

    private void InicializarInventario()
    {
        for(int i = 0; i < Inventory.Instance.NumeroSlots; i++)
        {
           Slot nuevoSlot = Instantiate(slotPrefab, container);
           slotsDisponibles.Add(nuevoSlot);
        }
    }
}
