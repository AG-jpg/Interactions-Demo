using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject ziman;
    private GameObject player;
    private BoxCollider2D bc;
    public GameObject missionBool;
    public GameObject arrowButton;
    public bool IsPaused;
    public bool chat;
    public Dialogue dialogue;
    public DialogueManager dm;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bc = GetComponent<BoxCollider2D>();
        dm = FindObjectOfType<DialogueManager>();
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

        if (chat && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 0;
            arrowButton.SetActive(true);
            missionBool.SetActive(false);
            Talk();
        }

        ShowMission();
    }

    public void Talk()
    {
        dialogueBox.SetActive(true);
        TriggerDialogue();
        IsPaused = true;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void ShowMission()
    {
        if (dm.DialogueEnded == true)
        {
            missionBool.SetActive(true);
            arrowButton.SetActive(false);
        }
    }
}
