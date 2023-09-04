using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void AtributoRespuesta(AttributeType type)
    {
        switch (type)
        {
            case AttributeType.Jawscript:
                break;
            case AttributeType.Timer:
                break;
            case AttributeType.Miner:
                break;
        }
    }

    private void OnEnable()
    {
        AttributesButton.EventAddAtribute += AtributoRespuesta;
    }

    private void OnDisable()
    {
        AttributesButton.EventAddAtribute -= AtributoRespuesta;
    }

}
