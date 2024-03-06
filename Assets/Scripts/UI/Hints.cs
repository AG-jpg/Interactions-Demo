using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject dialogueBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            dialogue.SetActive(true);
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            Destroy(gameObject);
            Destroy(dialogue);
            Destroy(dialogueBox);
        }
    }
}
