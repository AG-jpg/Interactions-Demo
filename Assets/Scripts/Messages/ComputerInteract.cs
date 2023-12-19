using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    [Header("Messages")]
    [SerializeField] private GameObject panelMessage;
    [SerializeField] private GameObject bg;
    public int messagesRead = 0;
    private bool readingMessage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && readingMessage == true)
        {
            panelMessage.SetActive(true);
            bg.SetActive(true);
            messagesRead++;
            readingMessage = false;
        }
    }

    public void ClosePanel()
    {
        panelMessage.SetActive(true);
        bg.SetActive(true);
        Destroy(this.gameObject);
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
