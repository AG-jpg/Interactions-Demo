using TMPro;
using UnityEngine;

public class InspectorQuest : QuestDescription
{
    [SerializeField] private TextMeshProUGUI questReward;
    public override void ConfigureQuestUI(Quest questtoLoad)
    {
        base.ConfigureQuestUI(questtoLoad);
        questReward.text =  $"{questtoLoad.Credits} Credits" +
                            $"{questtoLoad.Experience} Exp" +
                            $"{questtoLoad.RewardItem.Item.Name} x{questtoLoad.RewardItem.cantidad}";
    }
}