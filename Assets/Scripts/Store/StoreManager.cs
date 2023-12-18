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

    private bool ReadyforStore;

    private void Update()
    {
        if (itemsAvailable.Length <= 0)
        {
            ReadyforStore = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) && ReadyforStore == true)
        {
            GetItems();
            ReadyforStore = false;
            LoadItemsinStore();
        }
    }

    private void GetItems()
    {
        for (int i = 0; i < itemsforSale.Length; i++)
        {
            if (itemsforSale[i].storeActive == true && ReadyforStore == true)
            {
                itemsAvailable = itemsforSale[i].storeItems;
            }
        }
    }

    private void LoadItemsinStore()
    {
        for (int i = 0; i < itemsAvailable.Length; i++)
        {
            Store iteminStore = Instantiate(itemPrefab, panelContainer);
            iteminStore.ConfigureItemSale(itemsAvailable[i]);
        }
    }

    public void FlushStore()
    {
        itemsAvailable = new ItemVenta[0];
    }
}
