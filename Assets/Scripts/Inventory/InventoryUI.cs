using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Panel Descripción")]
    [SerializeField] private TextMeshProUGUI descripcion;
    [SerializeField] private TextMeshProUGUI itemName;

    [SerializeField] private Slot slotPrefab;
    [SerializeField] private Transform container;

    public Slot SelectedSlot { get; private set; }
    private List<Slot> slotsDisponibles = new List<Slot>();

    void Start()
    {
        InicializarInventario();
    }

    private void Update()
    {
        UpdateSlectedSlot();
    }

    private void InicializarInventario()
    {
        for (int i = 0; i < Inventory.Instance.NumeroSlots; i++)
        {
            Slot nuevoSlot = Instantiate(slotPrefab, container);
            nuevoSlot.Index = i;
            slotsDisponibles.Add(nuevoSlot);
        }
    }

    private void UpdateSlectedSlot()
    {
        GameObject goselected = EventSystem.current.currentSelectedGameObject;
        if (goselected == null)
        {
            return;
        }

        Slot slot = goselected.GetComponent<Slot>();
        if (slot != null)
        {
            SelectedSlot = slot;
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
        if (Inventory.Instance.ItemsInventario[index] != null)
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

    public void UsarItem()
    {
        if(SelectedSlot != null)
        {
            SelectedSlot.SlotUseItem();
        }
    }

    public void RemoveItem()
    {
        if(SelectedSlot != null)
        {
            SelectedSlot.SlotRemoveItem();
        }
    }

    #region Events

    private void SlotRespuesta(TiposInteraccion tipo, int index)
    {
        if (tipo == TiposInteraccion.Click)
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

    #endregion
}
