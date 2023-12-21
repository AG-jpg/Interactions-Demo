using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SoundManager soundManager;
    public Stats stats;
    public Energy Energy { get; private set; }
    public Experience Experience { get; private set; }

    public static Player instance;

    private void Awake()
    {
        Energy = GetComponent<Energy>();
        Experience = GetComponent<Experience>();
    }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Food"))
        {
            soundManager.UseItem();
        }
    }

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

        stats.PuntosDisponibles -= 1;
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
