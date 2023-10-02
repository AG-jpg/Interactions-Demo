using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questDescription;

    public Quest questLoaded { get; set; }

    public virtual void ConfigureQuestUI(Quest quest)
    {
        questName.text = quest.Name;
        questDescription.text = quest.Description;
    }

}
