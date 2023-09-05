using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stats stats;
    private void AtributoRespuesta(AttributeType type)
    {
        if (stats.PuntosDisponibles <= 0)
        {
            return;
        }

        switch (type)
        {
            case AttributeType.Jawscript:
                stats.Jawscript++;
                stats.AddBonusJawscript();
                break;
            case AttributeType.Timer:
                stats.Timer++;
                stats.AddBonusTimer();
                break;
            case AttributeType.Miner:
                stats.Miner++;
                stats.AddBonusMiner();
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
