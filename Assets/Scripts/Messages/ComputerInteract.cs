using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : Singleton<ComputerInteract>
{
    [Header("Messages")]
    [SerializeField] private GameObject panelMessage;
    [SerializeField] private GameObject bg;
    public bool readingMessage;

    private void Start()
    {
        readingMessage = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && readingMessage == true)
        {
            panelMessage.SetActive(true);
            bg.SetActive(true);
            QuestManager.Instance.messagesRead = true;
            SoundManager.Instance.ReadMessage();
            readingMessage = false;
        }
    }

    public void ClosePanel()
    {
        bg.SetActive(false);
        readingMessage = false;
        Destroy(this.gameObject);
        Destroy(panelMessage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            readingMessage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        readingMessage = false;
    }
}
