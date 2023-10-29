using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Notifications
{


    public override void ConfigureNotificationUI(Popup notify)
    {
        Popup = notify;
        Popup.Description = notify.Description;
        Popup.Icon = notify.Icon;
        Popup.BG = notify.BG;
    }
}
