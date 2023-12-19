using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Message : ScriptableObject
{
    [Header("Info")]
    public string Title;
    public string Subtitle;
    [TextAreaAttribute] public string Content;
}
