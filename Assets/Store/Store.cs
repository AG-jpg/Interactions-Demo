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

    private int cantidadCompra;
    private int initialCost;
    private int actualCost;
    private void Update()
    {
        cantidad.text = cantidadCompra.ToString();
        itemCost.text = actualCost.ToString();
    }

    public void ConfigureItemSale(ItemVenta itemVenta)
    {
        itemLoaded = itemVenta;
        icon.sprite = itemVenta.Item.Icon;
        itemName.text = itemVenta.Item.Name;
        itemCost.text = itemVenta.Cost.ToString();
        cantidadCompra = 1;
        initialCost = itemVenta.Cost;
        actualCost = itemVenta.Cost;
    }

    public void AddItemtoBuy()
    {
        int purchaseCost = initialCost * (cantidadCompra + 1);
        if(MoneyManager.Instance.TotalCredits >= purchaseCost)
        {
            cantidadCompra++;
            actualCost = initialCost * cantidadCompra;
        }
    }

}
