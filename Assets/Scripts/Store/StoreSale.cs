using System;
using UnityEngine;

[CreateAssetMenu]
public class StoreSale : ScriptableObject
{
    [SerializeField] public ItemVenta[] storeItems;
}