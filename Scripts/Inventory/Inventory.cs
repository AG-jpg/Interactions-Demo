using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [Header("Items")]
    [SerializeField] private Item[] itemsInventario;
    [SerializeField] Player player;
    public int NumeroSlots => numeroSlots;

    [SerializeField] private int numeroSlots;
    public Item[] ItemsInventario => itemsInventario;
    public Player Player => player;

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

                        InventoryUI.Instance.DrawItemInventory(itemtoAdd, itemsInventario[indexes[i]].Cantidad, indexes[i]);
                        return;
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
                itemsInventario[i] = item.CopyItem();
                itemsInventario[i].Cantidad = cantidad;
                InventoryUI.Instance.DrawItemInventory(item, cantidad, i);
                return;
            }
        }
    }

    private void EliminarItem(int index)
    {
        ItemsInventario[index].Cantidad--;

        if (itemsInventario[index].Cantidad <= 0)
        {
            itemsInventario[index].Cantidad = 0;
            itemsInventario[index] = null;
            InventoryUI.Instance.DrawItemInventory(null, 0, index);
        }
        else
        {
            InventoryUI.Instance.DrawItemInventory(itemsInventario[index], itemsInventario[index].Cantidad, index);
        }
    }

    private void UsarItem(int index)
    {
        if (itemsInventario[index] == null)
        {
            return;
        }

        if (itemsInventario[index].UsarItem())
        {
            EliminarItem(index);
        }
    }

    #region Events

    private void SlotRespuesta(TiposInteraccion tipo, int index)
    {
        switch (tipo)
        {
            case TiposInteraccion.Usar:
                UsarItem(index);
                break;
            case TiposInteraccion.Dar:
                break;
            case TiposInteraccion.Remover:
                break;
                
        }
    }

    private void OnEnable()
    {
        Slot.EventoSlotInteraction += SlotRespuesta;
    }

    private void OnDisable()
    {
        Slot.EventoSlotInteraction -= SlotRespuesta;
    }

    #endregion

}
