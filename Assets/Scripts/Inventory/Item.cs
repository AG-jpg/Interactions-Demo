using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TiposItem
{
    Hardware, Food, Money, Usables
}

public class Item : ScriptableObject
{
    [Header("Parameter")]
    public string ID;
    public string Name;
    public Sprite Icon;
    [TextArea] public string Description;

    [Header("Information")]
    public TiposItem Tipo;
    public bool Consumible;
    public bool Acumulable;
    public int AcumulacionMax;

    [HideInInspector]    
    public int Cantidad;

    public Item CopyItem()
    {
        Item newInstance = Instantiate(this);
        return newInstance;
    }
}
