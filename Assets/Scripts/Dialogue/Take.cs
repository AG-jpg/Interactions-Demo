using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    public Dialogues dialogues;
    public void PressButton()
    {
        Time.timeScale = 1;
        dialogues.IsPaused = false;
        dialogues.chat = false;
        dialogues.dialogueBox.SetActive(false);
        dialogues.ziman.SetActive(false);
    }
}
