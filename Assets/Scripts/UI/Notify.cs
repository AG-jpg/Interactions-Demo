using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Notifications
{
    private static Notify instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Destroy(this.gameObject, 3);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public override void ConfigureNotificationUI(Popup popup)
    {
        base.ConfigureNotificationUI(popup);
        info.text = popup.Description;
        icon.sprite = popup.Icon;
        bg.sprite = popup.BG;
    }
}
