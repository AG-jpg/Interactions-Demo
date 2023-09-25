using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header ("Panel Descripción")]
    [SerializeField] private TextMeshProUGUI descripcion;
    [SerializeField] private TextMeshProUGUI itemName;

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
           nuevoSlot.Index = i;
           slotsDisponibles.Add(nuevoSlot);
        }
    }

    public void DrawItemInventory(Item itemtoAdd, int cantidad, int itemIndex)
    {
        Slot slot = slotsDisponibles[itemIndex];
        if (itemtoAdd != null)
        {
            slot.ActivarSlotUI(true);
            slot.ActualizarSlot(itemtoAdd, cantidad);
        }
        else
        {
            slot.ActivarSlotUI(false);
        }
    }

    private void UpdateDescription(int index)
    {
        if(Inventory.Instance.ItemsInventario[index] != null)
        {
            itemName.text = Inventory.Instance.ItemsInventario[index].Name;
            descripcion.text = Inventory.Instance.ItemsInventario[index].Description;
        }
        else
        {
            itemName.text = " ";
            descripcion.text = " ";
        }
    }

    private void SlotRespuesta(TiposInteraccion tipo, int index)
    {
        if(tipo == TiposInteraccion.Click)
        {
            UpdateDescription(index);
        }
    }

    private void OnEnable()
    {
        Slot.EventoSlotInteraction += SlotRespuesta;
    }

    private void OnDisable()
    {
        Slot.EventoSlotInteraction -= SlotRespuesta;
    }
}
