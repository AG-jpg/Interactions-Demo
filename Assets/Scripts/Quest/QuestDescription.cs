using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questDescription;

    public virtual void ConfigureQuestUI(Quest questtoLoad)
    {
        questName.text = questtoLoad.Name;
        questName.text = questtoLoad.Description;
    }

}
