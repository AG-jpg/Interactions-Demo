using System;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    [Header ("Info")]
    public string Name;
    public string ID;
    public int CantidadObjetivo;

    [Header("Description")]
    public string Description;

    [Header("Rewards")]
    public int Credits;
    public float Experience;
    public QuestRewardItem RewardItem;

    [HideInInspector] public int cantidadActual;
    [HideInInspector] bool QuestCompleted;

}

[Serializable]
public class QuestRewardItem
{ 
    public Item Item;
    public int cantidad;
}