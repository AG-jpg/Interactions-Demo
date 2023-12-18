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

    public ItemVenta itemLoaded { get; private set; }

    private int cantidadCompra;
    private int initialCost;
    private int actualCost;
    private void Update()
    {
        cantidad.text = cantidadCompra.ToString();
        itemCost.text = actualCost.ToString();

        CleanPanel();
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

    public void BuyItem()
    {
        if(MoneyManager.Instance.TotalCredits >= actualCost)
        {
            Inventory.Instance.AddItem(itemLoaded.Item, cantidadCompra);
            MoneyManager.Instance.RemoveCredits(actualCost);
            cantidadCompra = 1;
            actualCost = initialCost;
            UIManager.Instance.ShowPurchase();
        }
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

    public void SubstractItemtoBuy()
    {
        if(cantidadCompra == 1)
        {
            return;
        }

        cantidadCompra--;
        actualCost = initialCost * cantidadCompra;
    }

    public void CleanPanel()
    {
        if(StoreManager.Instance.cleanPanel == true)
        {
            Destroy(this.gameObject);
        }

        StoreManager.Instance.cleanPanel = false;
    }

}
