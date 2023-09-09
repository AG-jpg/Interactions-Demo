using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Object")]
    [SerializeField] private Stats Stats;
    [Header("Paneles")]
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelInventario;


    [Header("Barra")] 
    [SerializeField] private Image expPlayer;

    [Header("Texto")] 
    [SerializeField] private TextMeshProUGUI expTMP;

    private float expActual;
    private float expRequiredNewLevel;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI NextLevel;
    [SerializeField] private TextMeshProUGUI ExperienceNow;
    [SerializeField] private TextMeshProUGUI JawscriptStat;
    [SerializeField] private TextMeshProUGUI TimerStat;
    [SerializeField] private TextMeshProUGUI MinerStat;
    [SerializeField] private TextMeshProUGUI AtributeJawscript;
    [SerializeField] private TextMeshProUGUI AtributeTimer;
    [SerializeField] private TextMeshProUGUI AtributeMiner;
    [SerializeField] private TextMeshProUGUI AtributoDisponible;


    private void Update()
    {
        UpdateUIPlayer();
        UpdatePanelStats();
    }

    private void UpdatePanelStats()
    {
        if(panelStats.activeSelf == false)
        {
            return;
        }

        JawscriptStat.text = Stats.Jawscript.ToString();
        TimerStat.text = Stats.Timer.ToString();
        MinerStat.text = Stats.Miner.ToString();
        Level.text = Stats.Level.ToString();
        //NextLevel.text = Stats.ExpNextLevel.ToString();
        //ExperienceNow.text = Stats.Experience.ToString();

        AtributeJawscript.text = Stats.JawscriptSkill.ToString();
        AtributeTimer.text = Stats.TimerSkill.ToString();
        AtributeMiner.text = Stats.MinerSkill.ToString();
        AtributoDisponible.text = Stats.PuntosDisponibles.ToString();




    }
    private void UpdateUIPlayer()
    {
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, 
        expActual / expRequiredNewLevel, 10f * Time.deltaTime);

        expTMP.text = $"{expActual}/{expRequiredNewLevel}";
    }

    public void UpdateExpPlayer(float pExpActual, float pExpRequerida)
    {
        expActual = pExpActual;
        expRequiredNewLevel = pExpRequerida;
    }

    #region Panels

    public void OpenPanelStats()
    {
        panelStats.SetActive(!panelStats.activeSelf);
    }

    public void OpenPanelInventario()
    {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    #endregion
}
