using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Notifications
{
    
    public override void ConfigureNotificationUI(Popup popup)
    {
        base.ConfigureNotificationUI(popup);
        info.text = popup.Description;
        icon.sprite = popup.Icon;
        bg.sprite = popup.BG;
    }
}
