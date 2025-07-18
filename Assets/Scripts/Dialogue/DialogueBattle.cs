using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBattle : Singleton<DialogueBattle>
{
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] private Text NameText;
    [SerializeField] private Text DialogueText;
    [SerializeField] private Image npcIcon;
    [SerializeField] private NPCDialogue dialogue;
    [SerializeField] public GameObject generator;

    private Queue<string> sequence;
    private bool AnimatedDialogue;
    private bool ShowGoodbye;

    void Start()
    {
        sequence = new Queue<string>();
        ConfigurePanel(dialogue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (ShowGoodbye)
            {
                if (dialogue.hasExtra)
                {
                    UIManager.Instance.OpenPanelInteraction(dialogue.InteraccionExtra);
                    OpenPanel(false);
                }

                OpenPanel(false);
                generator.SetActive(true);
                ShowGoodbye = false;
                return;
            }

            if (AnimatedDialogue)
            {
                ContinueDialogue();
            }
        }
    }

    public void OpenPanel(bool state)
    {
        dialogueBox.SetActive(state);
    }

    private void ConfigurePanel(NPCDialogue dialogueNPC)
    {
        OpenPanel(true);
        npcIcon.sprite = dialogueNPC.Icon;
        LoadSentences(dialogueNPC);
        NameText.text = dialogueNPC.Name;
        ShowText(dialogueNPC.Entrance);
    }

    private void LoadSentences(NPCDialogue dialogueNPC)
    {
        if (dialogueNPC.Conversation == null || dialogueNPC.Conversation.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < dialogueNPC.Conversation.Length; i++)
        {
            sequence.Enqueue(dialogueNPC.Conversation[i].Sentence);
        }
    }

    private void ContinueDialogue()
    {

        if (ShowGoodbye)
        {
            return;
        }

        if (sequence.Count == 0)
        {
            string despedida = dialogue.Out;
            ShowText(despedida);
            ShowGoodbye = true;
            return;
        }

        string NextLine = sequence.Dequeue();
        ShowText(NextLine);
    }

    private IEnumerator AnimateText(string oracion)
    {
        AnimatedDialogue = false;
        DialogueText.text = "";
        char[] letras = oracion.ToCharArray();

        for (int i = 0; i < letras.Length; i++)
        {
            DialogueText.text += letras[i];
            yield return new WaitForSeconds(0.04f);
        }

        AnimatedDialogue = true;
    }

    private void ShowText(string oracion)
    {
        StartCoroutine(AnimateText(oracion));
    }
}
