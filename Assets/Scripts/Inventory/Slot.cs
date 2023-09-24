using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
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
}
