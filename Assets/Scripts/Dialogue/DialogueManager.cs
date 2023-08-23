using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] private Text NameText;
    [SerializeField] private Text DialogueText;

    public NPCInteract NPCDisponible { get; set; }

    private void Update()
    {
        if(NPCDisponible == null)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            ConfigurePanel(NPCDisponible.Dialogo);
        }
    }

    public void OpenPanel(bool state)
    {
        dialogueBox.SetActive(state);
    }

    private void ConfigurePanel(NPCDialogue dialogueNPC)
    {
        OpenPanel(true);
        NameText.text = dialogueNPC.Name;

    }
}
