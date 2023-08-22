using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    private GameObject player;
    private BoxCollider2D bc;
    public GameObject arrowButton;
    public bool chat;
    public Dialogue dialogue;
    public DialogueManager dm;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bc = GetComponent<BoxCollider2D>();
        dm = FindObjectOfType<DialogueManager>();
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
        if (chat && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 0;
            arrowButton.SetActive(true);
            Talk();
        }
    }

    public void Talk()
    {
        dialogueBox.SetActive(true);
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
