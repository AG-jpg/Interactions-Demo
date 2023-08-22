using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    public DialogueTrigger dialogues;
    public GameObject ziman;
    public void PressButton()
    {
        Time.timeScale = 1;
        dialogues.chat = false;
        dialogues.dialogueBox.SetActive(false);
        ziman.SetActive(false);
    }
}
