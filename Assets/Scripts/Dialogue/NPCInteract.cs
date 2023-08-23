using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    [SerializeField]
    private NPCDialogue dialogueNPC;

    public NPCDialogue Dialogo => dialogueNPC;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            DialogueManager.Instance.NPCDisponible = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            DialogueManager.Instance.NPCDisponible = null;
        }
    }
}
