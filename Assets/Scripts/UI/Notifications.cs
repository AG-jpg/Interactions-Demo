using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    [Header("Notifications")]
    [SerializeField] public TextMeshProUGUI Description;
    [SerializeField] public Image Icon;
    [SerializeField] public Image BG;

    public Popup Popup  { get; set; }

    public virtual void ConfigureNotificationUI(Popup notify)
    {
        Popup = notify;
        Popup.Description = notify.Description;
        Popup.Icon = notify.Icon;
        Popup.BG = notify.BG;
    }
}
