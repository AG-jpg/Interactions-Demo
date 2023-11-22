using TMPro;
using UnityEngine;

public class InspectorQuest : QuestDescription
{
    [SerializeField] private TextMeshProUGUI questReward;
    [SerializeField] private GameObject InpsectorContainer;

    public override void ConfigureQuestUI(Quest quest)
    {
        base.ConfigureQuestUI(quest);
        questReward.text =  $"{quest.Credits} Credits" +
                            $"    {quest.Experience} Exp" ;
                            //+ $" {quest.RewardItem.cantidad} {quest.RewardItem.Item.Name} ";
    }

   public void AcceptQuest()
    {
        if(QuestLoaded == null)
        {
            return;
        }

        QuestManager.Instance.AddQuest(QuestLoaded);
        Destroy(this.gameObject);
        UIManager.Instance.OpenPanelQuest();
    }

    public void DenyQuest()
    {
        QuestManager.Instance.ResetQuestList();
        Destroy(this.gameObject);
        UIManager.Instance.OpenPanelQuest();
    }
}