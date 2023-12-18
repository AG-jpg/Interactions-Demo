using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private Store itemPrefab;
    [SerializeField] private Transform panelContainer;

    [Header("Items")]
    [SerializeField] private StoreContainer[] itemsforSale;

    [SerializeField] private ItemVenta[] itemsAvailable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetItems();
            LoadItemsinStore();
        }
    }

    private void GetItems()
    {
        for(int i = 0; i < itemsforSale.Length; i++)
        {
            if(itemsforSale[i].storeActive == true)
            {
                itemsAvailable = itemsforSale[i].storeItems;
            }
            else if(itemsforSale[i].storeActive == false)
            {
                itemsAvailable = new ItemVenta[0];
            }
        }
    }
    private void LoadItemsinStore()
    {
        for(int i = 0; i < itemsAvailable.Length; i++)
        {
            Store iteminStore = Instantiate(itemPrefab, panelContainer);
            iteminStore.ConfigureItemSale(itemsAvailable[i]);
        }
    }
}
