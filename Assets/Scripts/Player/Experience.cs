using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private Stats stats;

    [Header("Config")]
    [SerializeField] private int levelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    private float ActualExperience;
    private float ExpActualTemporal;
    private float ReqExpNextlevel;

    // Start is called before the first frame update
    void Start()
    {
        stats.Level = 1;
        ReqExpNextlevel = expBase;
        stats.ExpNextLevel = ReqExpNextlevel;
        UpdateExpBar();
    }

    public void AddExp(float expObt)
    {
        if (expObt > 0f)
        {
            float expRestNextLevel = ReqExpNextlevel - ExpActualTemporal;
            if (expObt >= expRestNextLevel)
            {
                expObt -= expRestNextLevel;
                ActualExperience += expObt;
                UpdateLevel();
                AddExp(expObt);
            }
            else
            {
                ActualExperience += expObt;
                ExpActualTemporal += expObt;
                if (ExpActualTemporal == ReqExpNextlevel)
                {
                    UpdateLevel();
                }
            }
        }

        stats.Experience = ActualExperience;
        UpdateExpBar();
    }

    private void UpdateLevel()
    {
        if (stats.Level < levelMax)
        {
            stats.Level++;
            ExpActualTemporal = 0f;
            ReqExpNextlevel *= valorIncremental;
            stats.ExpNextLevel = ReqExpNextlevel;
            stats.PuntosDisponibles +=1;
        }
    }

    private void UpdateExpBar()
    {
        UIManager.Instance.UpdateExpPlayer(ExpActualTemporal, ReqExpNextlevel);
    }
}
