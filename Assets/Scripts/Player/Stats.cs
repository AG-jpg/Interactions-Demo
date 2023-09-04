using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    public float Level;
    public float Experience;
    public float ExpNextLevel;
    public float Jawscript = 1;
    public float Timer = 1;
    public float Miner = 1;

    [Header("Atributos")]
    public int JawscriptSkill;
    public int TimerSkill;
    public int MinerSkill;

    [HideInInspector]
    public int PuntosDisponibles;


    public void ResetValues()
    {
        Level = 1;
        Jawscript = 1;
        Timer = 1;
        Miner = 1;
        Experience = 0;
        ExpNextLevel = 0;
    }
}
