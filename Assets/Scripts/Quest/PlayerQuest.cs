using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerQuest : QuestDescription
{
    //[SerializeField] private TextMeshProUGUI creditsReward;
    //[SerializeField] private TextMeshProUGUI expReward;
    [SerializeField] private TextMeshProUGUI task;

    private void Update()
    {
        if(QuestLoaded.QuestCompletedCheck == true)
        {
            return;
        }

         task.text = $"Task: {QuestLoaded.cantidadActual} / {QuestLoaded.CantidadObjetivo}";
    }

    public override void ConfigureQuestUI(Quest quest)
    {
        base.ConfigureQuestUI(quest);
        //creditsReward.text = questtoLoad.Credits.ToString();
        //expReward.text = questtoLoad.Experience.ToString();
        task.text = $"Task: {quest.cantidadActual} / {quest.CantidadObjetivo}";
    }

    private void QuestCompletadoRespuesta(Quest questCompletado)
    {
        if (questCompletado.ID == QuestLoaded.ID)
        {
            task.text = $"Task: {QuestLoaded.cantidadActual} / {QuestLoaded.CantidadObjetivo}";
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if(QuestLoaded.QuestCompletedCheck)
        {
            gameObject.SetActive(false);
        }
        Quest.EventQuestCompleted += QuestCompletadoRespuesta;
    }

    private void OnDisable()
    {
        Quest.EventQuestCompleted -= QuestCompletadoRespuesta;
    }
}
