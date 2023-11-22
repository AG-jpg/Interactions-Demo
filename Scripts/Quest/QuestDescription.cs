using TMPro;
using UnityEngine;

public class QuestDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questDescription;

    public Quest QuestLoaded  { get; set; }

    public virtual void ConfigureQuestUI(Quest quest)
    {
        QuestLoaded = quest;
        questName.text = quest.Name;
        questDescription.text = quest.Description;
    }

}
