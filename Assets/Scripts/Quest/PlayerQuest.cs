using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerQuest : QuestDescription
{
    [SerializeField] private TextMeshProUGUI creditsReward;
    [SerializeField] private TextMeshProUGUI expReward;
    [SerializeField] private TextMeshProUGUI task;

    public override void ConfigureQuestUI(Quest questtoLoad)
    {
        base.ConfigureQuestUI(questtoLoad);
        creditsReward.text = questtoLoad.Credits.ToString();
        expReward.text = questtoLoad.Experience.ToString();
        task.text = $"Task: {questtoLoad.cantidadActual} / {questtoLoad.CantidadObjetivo}";
    }
}
