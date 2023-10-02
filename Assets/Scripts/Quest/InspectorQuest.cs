using TMPro;
using UnityEngine;

public class InspectorQuest : QuestDescription
{
    [SerializeField] private TextMeshProUGUI questReward;
    public override void ConfigureQuestUI(Quest quest)
    {
        base.ConfigureQuestUI(quest);
        questLoaded = quest;
        questReward.text =  $"{quest.Credits} Credits" +
                            $"    {quest.Experience} Exp" ;
                            //+ $" {quest.RewardItem.cantidad} {quest.RewardItem.Item.Name} ";
    }

    public void AcceptQuest()
    {
        if(questLoaded == null)
        {
            return;
        }

        QuestManager.Instance.AddQuest(questLoaded);
        gameObject.SetActive(false);
    }
}