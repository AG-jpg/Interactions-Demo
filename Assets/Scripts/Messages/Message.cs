using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Message : ScriptableObject
{
    [Header("Info")]
    public Image icon;
    public string Title;
    public string Subtitle;
    [TextAreaAttribute] public string Text;
}
