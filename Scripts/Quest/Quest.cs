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

    [HideInInspector] public int cantidadActual;
    [HideInInspector] public bool QuestCompletedCheck;

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
        if(QuestCompletedCheck)
        {
            return;
        }

        QuestCompletedCheck = true;
        EventQuestCompleted?.Invoke(this);
    }

    private void OnEnable()
    {
        QuestCompletedCheck = false;
        cantidadActual = 0;
    }

}