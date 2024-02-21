using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public QuestManager questManager;
    public SoundManager soundManager;
    public StoreManager storeManager;

    [Header("Object")]
    [SerializeField] private Stats Stats;
    [SerializeField] private GameObject bg;
    [SerializeField] public GameObject UIBox;

    [Header("Paneles")]
    [SerializeField] private GameObject panelID;
    [SerializeField] private GameObject panelWallet;
    [SerializeField] private GameObject panelContacts;
    [SerializeField] private GameObject panelMap;
    [SerializeField] private GameObject panelTasks;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject panelQuest;
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelPC;
    [SerializeField] private GameObject panelMusic;
    [SerializeField] private GameObject panelStore;

    [SerializeField] private GameObject panelEmail;

    [Header("Barra")]
    [SerializeField] private Image expPlayer;
    [SerializeField] private Image energyPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI energyTMP;
    [SerializeField] private TextMeshProUGUI creditsTMP;

    private float expActual;
    private float expRequiredNewLevel;
    private float energyActual;
    private float energyMax;
    public int sceneID;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI Level;
    //[SerializeField] private TextMeshProUGUI NextLevel;
    //[SerializeField] private TextMeshProUGUI ExperienceNow;
    [SerializeField] private TextMeshProUGUI JawscriptStat;
    [SerializeField] private TextMeshProUGUI TimerStat;
    [SerializeField] private TextMeshProUGUI MinerStat;
    [SerializeField] private TextMeshProUGUI AtributeJawscript;
    [SerializeField] private TextMeshProUGUI AtributeTimer;
    [SerializeField] private TextMeshProUGUI AtributeMiner;
    [SerializeField] private TextMeshProUGUI AtributoDisponible;

    [Header("Notifications")]
    [SerializeField] private Notify notificationsPrefab;
    [SerializeField] private Transform notificationsContainer;
    [SerializeField] public Popup infoAccepted;
    [SerializeField] public Popup succeed;
    [SerializeField] public Popup saving;
    [SerializeField] public Popup purchase;
    [SerializeField] public Popup doors;

    [Header("Booleans")]
    public bool QuestStarted;
    public static bool gameIsPaused;
    private bool giveAway;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!giveAway)
            {
                gameIsPaused = !gameIsPaused;
                PauseGame();
            }
            else if (giveAway)
            {
                CloseGiveAway();
            }
        }

        UpdateUIPlayer();
        UpdatePanelStats();
        ShowNotification();
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
            UIBox.SetActive(!UIBox.activeSelf);
            panelID.SetActive(!panelID.activeSelf);
            bg.SetActive(!bg.activeSelf);
        }
        else
        {
            ExitPanels();
        }
    }

    public void ExitPanels()
    {
        Time.timeScale = 1;
        CloseAllPanels();
        UIBox.SetActive(!UIBox.activeSelf);
        bg.SetActive(!bg.activeSelf);
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
        creditsTMP.text = MoneyManager.Instance.TotalCredits.ToString();
        Level.text = Stats.Level.ToString();
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

    #region Notifications

    public void ShowNotification()
    {
        if (questManager.QuestAccepted == true)
        {
            Notifications newNotification = Instantiate(notificationsPrefab, notificationsContainer);
            newNotification.ConfigureNotificationUI(infoAccepted);
            questManager.QuestAccepted = false;
            QuestStarted = true;
            soundManager.Notify();
        }
    }

    public void ShowPurchase()
    {
        Notifications newNotification = Instantiate(notificationsPrefab, notificationsContainer);
        newNotification.ConfigureNotificationUI(purchase);
        soundManager.Purchase();
    }

    public void SavedNotification()
    {
        Notifications newNotification = Instantiate(notificationsPrefab, notificationsContainer);
        newNotification.ConfigureNotificationUI(saving);
        soundManager.Saving();
    }

    public void ShowSuccesNotification()
    {
        Notifications newNotification = Instantiate(notificationsPrefab, notificationsContainer);
        newNotification.ConfigureNotificationUI(succeed);
        soundManager.Success();
    }

    public void DoorsNotification()
    {
        Notifications newNotification = Instantiate(notificationsPrefab, notificationsContainer);
        newNotification.ConfigureNotificationUI(doors);
        soundManager.OpenDoors();
    }

    #endregion

    #region Panels

    public void CloseEmail()
    {
        Destroy(panelEmail);
        bg.SetActive(false);
    }

    public void OpenPanelID()
    {
        CloseAllPanels();
        panelID.SetActive(!panelID.activeSelf);
    }

    public void OpenPanelWallet()
    {
        CloseAllPanels();
        panelWallet.SetActive(!panelWallet.activeSelf);
    }

    public void OpenPanelContacts()
    {
        CloseAllPanels();
        panelContacts.SetActive(!panelContacts.activeSelf);
    }

    public void OpenPanelMaps()
    {
        CloseAllPanels();
        panelMap.SetActive(!panelMap.activeSelf);
    }

    public void OpenPanelTasks()
    {
        CloseAllPanels();
        panelTasks.SetActive(!panelTasks.activeSelf);
    }

    public void OpenPanelInventario()
    {
        CloseAllPanels();
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    public void OpenPanelStats()
    {
        CloseAllPanels();
        panelStats.SetActive(!panelStats.activeSelf);
    }

    public void OpenPanelPC()
    {
        CloseAllPanels();
        panelPC.SetActive(!panelPC.activeSelf);
    }

    public void OpenPanelMusic()
    {
        CloseAllPanels();
        panelMusic.SetActive(!panelMusic.activeSelf);
    }

    public void OpenPanelQuest()
    {
        panelQuest.SetActive(!panelQuest.activeSelf);
    }

    public void OpenPanelStore()
    {
        CloseAllPanels();
        panelStore.SetActive(!panelStore.activeSelf);
        bg.SetActive(!bg.activeSelf);
    }

    public void FlushStore()
    {
        OpenPanelStore();
        storeManager.FlushStore();
    }

    public void GiveAway()
    {
        giveAway = true;
        panelInventario.SetActive(!panelInventario.activeSelf);
        UIBox.SetActive(!UIBox.activeSelf);
        bg.SetActive(!bg.activeSelf);
    }

    public void CloseGiveAway()
    {
        giveAway = false;
        CloseAllPanels();
        UIBox.SetActive(!UIBox.activeSelf);
        bg.SetActive(!bg.activeSelf);
    }

    public void Battle()
    {
        Player.Instance.SaveLocation();
        SceneManager.LoadScene(sceneID);
    }

    public void CloseAllPanels()
    {
        panelID.SetActive(false);
        panelWallet.SetActive(false);
        panelContacts.SetActive(false);
        panelMap.SetActive(false);
        panelTasks.SetActive(false);
        panelInventario.SetActive(false);
        panelStats.SetActive(false);
        panelPC.SetActive(false);
        panelMusic.SetActive(false);
    }

    public void OpenPanelInteraction(InteractionExtraNPC tipoInteraccion)
    {
        switch (tipoInteraccion)
        {
            case InteractionExtraNPC.Quests:
                OpenPanelQuest();
                break;
            case InteractionExtraNPC.Tienda:
                OpenPanelStore();
                break;
            case InteractionExtraNPC.Crafting:
                break;
            case InteractionExtraNPC.Gift:
                GiveAway();
                break;
                case InteractionExtraNPC.Ride:
                NPCManager.Instance.FinishRide();
                break;
            case InteractionExtraNPC.Battle:
                Battle();
                break;
        }
    }

    #endregion

}
