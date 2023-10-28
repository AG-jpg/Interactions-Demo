using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupContainer : Notifications
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image icon;
    [SerializeField] private Image bg;

    public override void ConfigureNotificationUI(Popup popup)
    {
        base.ConfigureNotificationUI(popup);
        description.text = popup.Description;
        icon.sprite = popup.Icon;
        bg.sprite = popup.BG;
    }
}
