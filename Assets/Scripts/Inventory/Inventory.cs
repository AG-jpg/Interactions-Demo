using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int numeroSlots;
    public int NumeroSlots => numeroSlots;

    [Header("Items")]
    [SerializeField] private Item[] itemsInventario;

    private void Start()
    {
        itemsInventario = new Item[numeroSlots];
    }

    public void AddItem(Item itemtoAdd, int cantidad)
    {
        if (itemtoAdd == null)
        {
            return;
        }

        List<int> indexes = VerificarExistencias(itemtoAdd.ID);
        if (itemtoAdd.Acumulable)
        {
            if (indexes.Count > 0)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (itemsInventario[indexes[i]].Cantidad < itemtoAdd.AcumulacionMax)
                    {
                        itemsInventario[indexes[i]].Cantidad += cantidad;
                        if (itemsInventario[indexes[i]].Cantidad > itemtoAdd.AcumulacionMax)
                        {
                            int diferencia = itemsInventario[indexes[i]].Cantidad - itemtoAdd.AcumulacionMax;
                            itemsInventario[indexes[i]].Cantidad = itemtoAdd.AcumulacionMax;
                            AddItem(itemtoAdd, diferencia);
                        }
                    }
                }
            }
        }

        if (cantidad <= 0)
        {
            return;
        }

        if (cantidad > itemtoAdd.AcumulacionMax)
        {
            AddItemInSlot(itemtoAdd, itemtoAdd.AcumulacionMax);
            cantidad -= itemtoAdd.AcumulacionMax;
            AddItem(itemtoAdd, cantidad);
        }
        else
        {
            AddItemInSlot(itemtoAdd, cantidad);
        }

    }

    private List<int> VerificarExistencias(string itemID)
    {
        List<int> indexItem = new List<int>();
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] != null)
            {
                if (itemsInventario[i].ID == itemID)
                {
                    indexItem.Add(i);
                }
            }


        }

        return indexItem;
    }

    private void AddItemInSlot(Item item, int cantidad)
    {
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] == null)
            {
                itemsInventario[i] = item;
                itemsInventario[i].Cantidad = cantidad;
                return;
            }
        }
    }

}
