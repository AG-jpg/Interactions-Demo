using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TiposInteraccion
{
    Click,
    Usar,
    Dar,
    Remover
}
public class Slot : MonoBehaviour
{
    public static Action<TiposInteraccion, int> EventoSlotInteraction;

    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject fondo;
    [SerializeField] private TextMeshProUGUI cantidadTMP;
    public int Index { get; set; }

    public void ActualizarSlot(Item item, int cantidad)
    {
        itemIcon.sprite = item.Icon;
        cantidadTMP.text = cantidad.ToString();
    }

    public void ActivarSlotUI(bool state)
    {
        itemIcon.gameObject.SetActive(state);
        fondo.SetActive(state);
    }

    public void ClickSlot()
    {
        EventoSlotInteraction?.Invoke(TiposInteraccion.Click, Index);
    }

    public void SlotUseItem()
    {
        if(Inventory.Instance.ItemsInventario[Index] != null)
        {
            EventoSlotInteraction?.Invoke(TiposInteraccion.Usar, Index);
        }
    }

    public void SlotRemoveItem()
    {
        if(Inventory.Instance.ItemsInventario[Index] != null)
        {
            EventoSlotInteraction?.Invoke(TiposInteraccion.Remover, Index);
        }
    }
}
