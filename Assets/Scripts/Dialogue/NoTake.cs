using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTake : MonoBehaviour
{
    public DialogueTrigger dialogues;
    public void PressButton()
    {
        Time.timeScale = 1;
        dialogues.IsPaused = false;
        dialogues.chat = true;
        dialogues.dialogueBox.SetActive(false);
        dialogues.ziman.SetActive(true);
    }
}
