using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    [Header("Notifications")]
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private Image Icon;
    [SerializeField] private Image BG;

    public Popup popup  { get; set; }

    public virtual void ConfigureNotificationUI(Popup notify)
    {
        popup = notify;
        popup.Description = notify.Description;
        popup.Icon = notify.Icon;
        popup.BG = notify.BG;
    }
}
