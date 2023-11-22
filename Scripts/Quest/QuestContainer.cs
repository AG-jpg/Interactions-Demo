using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestContainer : MonoBehaviour
{
    [Header("Info")]
    public string Name;

    [Header("Quests")]
    [SerializeField] public Quest Quests;

    public bool NPCActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                NPCActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NPCActive = false;
        }
    }
}
