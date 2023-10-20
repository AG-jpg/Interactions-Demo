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
    [SerializeField] private GameObject panelID;
    [SerializeField] private GameObject panelWallet;
    [SerializeField] private GameObject panelContacts;
    [SerializeField] private GameObject panelMap;
    [SerializeField] private GameObject panelTasks;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject panelQuest;
    [SerializeField] private GameObject panelMachine;
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelPC;
    [SerializeField] private GameObject panelMusic;



    [Header("Barra")]
    [SerializeField] private Image expPlayer;
    [SerializeField] private Image energyPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI energyTMP;

    private float expActual;
    private float expRequiredNewLevel;
    private float energyActual;
    private float energyMax;

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
        if (panelStats.activeSelf == false)
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

        energyPlayer.fillAmount = Mathf.Lerp(energyPlayer.fillAmount,
        energyActual / energyMax, 10f * Time.deltaTime);

        expTMP.text = $"{expActual}/{expRequiredNewLevel}";
        energyTMP.text = $"{energyActual}/{energyMax}";
    }

    public void UpdateExpPlayer(float pExpActual, float pExpRequerida)
    {
        expActual = pExpActual;
        expRequiredNewLevel = pExpRequerida;
    }

    public void UpdateEnergyPlayer(float pEnergyActual, float pEnergyMax)
    {
        energyActual = pEnergyActual;
        energyMax = pEnergyMax;
    }

    #region Panels

    public void OpenPanelID()
    {
        panelID.SetActive(!panelID.activeSelf);
    }

    public void OpenPanelWallet()
    {
        panelWallet.SetActive(!panelWallet.activeSelf);
    }

    public void OpenPanelContacts()
    {
        panelContacts.SetActive(!panelContacts.activeSelf);
    }

    public void OpenPanelMaps()
    {
        panelMap.SetActive(!panelMap.activeSelf);
    }

    public void OpenPanelTasks()
    {
        panelTasks.SetActive(!panelTasks.activeSelf);
    }

    public void OpenPanelInventario()
    {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    public void OpenPanelStats()
    {
        panelStats.SetActive(!panelStats.activeSelf);
    }

    public void OpenPanelPC()
    {
        panelPC.SetActive(!panelPC.activeSelf);
    }

    public void OpenPanelMusic()
    {
        panelMusic.SetActive(!panelMusic.activeSelf);
    }

    public void OpenPanelQuest()
    {
        panelQuest.SetActive(!panelQuest.activeSelf);
    }

    public void OpenPanelMachine()
    {
        panelMachine.SetActive(!panelMachine.activeSelf);
    }

    public void OpenPanelInteraction(InteractionExtraNPC tipoInteraccion)
    {
        switch (tipoInteraccion)
        {
            case InteractionExtraNPC.Quests:
            OpenPanelQuest();
                break;
            case InteractionExtraNPC.Tienda:
                break;
            case InteractionExtraNPC.Crafting:
                break;
        }
    }

    #endregion

}
