using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class Experience : Singleton<Experience>
{
    [Header("Stats")]
    [SerializeField] private Stats stats;

    [Header("Config")]
    [SerializeField] private int levelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    private readonly string STATS_KEY = "Stats105020";

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
        SaveStats();
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
            SaveStats();
        }
    }

    private void UpdateExpBar()
    {
        UIManager.Instance.UpdateExpPlayer(ExpActualTemporal, ReqExpNextlevel);
    }

    #region Saving

    public StatsData savedData;
    public void SaveStats()
    {
        savedData = new StatsData();
        savedData.levelData = stats.Level;
        savedData.experienceData = stats.Experience;
        savedData.jawscriptData = stats.Jawscript;
        savedData.timerData = stats.Timer;
        savedData.minerData = stats.Miner;

        SaveGame.Save(STATS_KEY, savedData);
    }

    #endregion

}
