using System;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public static Action<Quest> EventQuestCompleted;

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

    public void AddProgress(int cantidad)
    {
        cantidadActual += cantidad;
        VerifyCompletedQuest();
    }

    private void VerifyCompletedQuest()
    {
        if(cantidadActual >= CantidadObjetivo)
        {
            cantidadActual = CantidadObjetivo;
            CompletedQuest();
        }
    }

    private void CompletedQuest()
    {
        if(QuestCompleted)
        {
            return;
        }

        QuestCompleted = true;
        EventQuestCompleted?.Invoke(this);
    }

}

[Serializable]
public class QuestRewardItem
{ 
    public Item Item;
    public int cantidad;
}