using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionExtraNPC
{
    Quests,
    Tienda,
    Crafting,
    Gift,
    Ride,
    Battle
}

[CreateAssetMenu]
public class NPCDialogue : ScriptableObject 
{
    [Header("Info")]
    public string Name;
    public Sprite Icon;
    public bool hasExtra;
    public InteractionExtraNPC InteraccionExtra;

    [Header("Saludo")]
    [TextArea] public string Entrance;

    [Header("Chat")]
    public DialogueText[] Conversation;

    [Header("Despedida")]
    [TextArea] public string Out;

}

[System.Serializable]
public class DialogueText
{
    [TextArea] public string Sentence;
}
