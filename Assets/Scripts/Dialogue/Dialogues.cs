using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject ziman;
    private GameObject player;
    private BoxCollider2D bc;
    public bool IsPaused;
    public bool chat;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bc = GetComponent<BoxCollider2D>();
        ziman.SetActive(true);
        IsPaused = false;
        chat = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chat = true;
        }
    }

    private void Update()
    {
        if (IsPaused)
        {
            Time.timeScale = 0;
        }

        if(chat && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 0;
            Talk();
        }
    }

    public void Talk()
    {
        dialogueBox.SetActive(true);
        IsPaused = true;
    }
}
