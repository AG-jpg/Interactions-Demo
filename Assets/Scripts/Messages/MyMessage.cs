using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyMessage : ShowMessage
{
    private static MyMessage instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public override void ConfigureMessage(Message message)
    {
        base.ConfigureMessage(message);
        title.text = message.Title;
        subtitle.text = message.Subtitle;
        content.text = message.Content;
    }
}
