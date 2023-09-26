using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Food Item")]
public class ItemFood : Item
{
    [Header("Info")]
    public float HPRestore;

    public override bool UsarItem()
    {
        if (Inventory.Instance.Player.Energy.CanRestore)
        {
            Inventory.Instance.Player.Energy.RestoreEnergy(HPRestore);
            return true;
        }

        return false;
    }

}