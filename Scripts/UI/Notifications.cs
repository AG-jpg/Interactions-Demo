using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI info;
    [SerializeField] public Image icon;
    [SerializeField] public Image bg;
    public Popup PopupLoad  { get; set; }

    public virtual void ConfigureNotificationUI(Popup popup)
    {
        PopupLoad = popup;
        info.text = popup.Description;
        icon.sprite = popup.Icon;
        bg.sprite = popup.BG;
    }
}
