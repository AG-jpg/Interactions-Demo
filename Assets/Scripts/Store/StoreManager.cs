using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private Store itemPrefab;
    [SerializeField] private Transform panelContainer;

    [Header("Items")]
    [SerializeField] private StoreSale[] itemsInStore;

    [SerializeField] private ItemVenta[] itemsAvailable;
    
    private void Start()
    {
        LoadItemsinStore();
    }

    private void GetItems()
    {
        for(int i = 0; i < itemsInStore.Length; i++)
        {
            if(itemsInStore[i] != null)
            {
                itemsAvailable = itemsInStore[i].storeItems;
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
