using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private Store itemPrefab;
    [SerializeField] private Transform panelContainer;

    [Header("Items")]
    [SerializeField] private StoreContainer[] itemsInStore;

    [SerializeField] private ItemVenta[] itemsAvailable;

    private void Update()
    {
        GetItems();
        LoadItemsinStore();
    }

    private void GetItems()
    {
        for(int i = 0; i < itemsInStore.Length; i++)
        {
            if(itemsInStore[i].storeActive == true)
            {
                itemsAvailable = itemsInStore[i].storeItems;
            }
            else if(itemsInStore[i].storeActive == false)
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
