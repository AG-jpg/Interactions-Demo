using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class Player : Singleton<Player>
{
    public SoundManager soundManager;
    public Stats stats;
    public Vector3 location;
    public Energy Energy { get; private set; }
    public Experience Experience { get; private set; }

    public static Player instance;
    private readonly string PLAYER_KEY = "Player105020";

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Energy = GetComponent<Energy>();
        Experience = GetComponent<Experience>();
    }

    private void Update()
    {
        location = Player.instance.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            soundManager.UseItem();
        }

        if (other.CompareTag("Interactive"))
        {
            SaveLocation();
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

    #region Saving

    public PlayerData savedData;
    private void SaveLocation()
    {
        savedData = new PlayerData();
        savedData.locationData = new Vector3();
        savedData.locationData = location;

        SaveGame.Save(PLAYER_KEY, savedData);
    }

    #endregion

}
