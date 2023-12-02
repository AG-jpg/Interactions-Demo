using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCost;
    [SerializeField] private TextMeshProUGUI cantidad;

    public ItemVenta itemLoaded { get; set; }

    public void ConfigureItemSale(ItemVenta itemVenta)
    {
        itemLoaded = itemVenta;
        icon.sprite = itemVenta.Item.Icon;
        itemName.text = itemVenta.Item.Name;
        itemCost.text = itemVenta.Cost.ToString();
    }

}
