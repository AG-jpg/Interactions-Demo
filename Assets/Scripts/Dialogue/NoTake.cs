using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTake : MonoBehaviour
{
    public DialogueTrigger dialogues;
    public GameObject ziman;
    public void PressButton()
    {
        Time.timeScale = 1;
        dialogues.chat = true;
        dialogues.dialogueBox.SetActive(false);
        ziman.SetActive(true);
    }
}
