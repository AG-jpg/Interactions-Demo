using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
   [SerializeField] private NPCDialogue dialogueNPC;
    [SerializeField] private GameObject hint;

    public NPCDialogue Dialogo => dialogueNPC;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            DialogueManager.Instance.NPCDisponible = this;
            hint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            DialogueManager.Instance.NPCDisponible = null;
            hint.SetActive(false);
        }
    }
}
