using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    [Header("Messages")]
    [SerializeField] private MyMessage messagePrefab;
    [SerializeField] private Transform messageContainer;
    [SerializeField] private Message message;
    public int messagesRead = 0;
    private bool readingMessage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && readingMessage == true)
        {
            UIManager.Instance.OpenPanelMessage();
            ShowMessage newMessage = Instantiate(messagePrefab, messageContainer);
            newMessage.ConfigureMessage(message);
            messagesRead++;
            readingMessage = false;
        }

        if(UIManager.Instance.messageClosed == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            readingMessage = true;
        }
    }
}
