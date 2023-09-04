using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Jawscript,
    Timer,
    Miner
}
public class AttributesButton : MonoBehaviour
{

    public static Action<AttributeType> EventAddAtribute;
    [SerializeField] private AttributeType type;

    public void AddAtribute()
    {
        EventAddAtribute?.Invoke(type);
    }

}
