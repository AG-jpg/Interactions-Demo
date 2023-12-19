using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowMessage : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI title;
    [SerializeField] public TextMeshProUGUI subtitle;
    [SerializeField] public TextMeshProUGUI content;

    public Message loadMessage  { get; set; }

    public virtual void ConfigureMessage(Message message)
    {
        loadMessage = message;
        title.text = message.Title;
        subtitle.text = message.Subtitle;
        content.text = message.Content;

    }
}
