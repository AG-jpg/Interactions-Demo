using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int numeroSlots;
    public int NumeroSlots => numeroSlots;

    [Header ("Items")]
    [SerializeField] private Item[] itemsInventario;

    private void Start()
    {
        itemsInventario = new Item[numeroSlots];
    }

    private void AddItem(Item itemtoAdd,int Cantidad)
    {
        if(itemtoAdd == null)
        {
            return;
        }
    }

    private List<int> VerificarExistencias(string itemID)
    {
        List<int> indexItem = new List<int>();
        for (int i=0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i].ID == itemID)
            {
                indexItem.Add(i);
            }
        }

        return indexItem;
    }

}
