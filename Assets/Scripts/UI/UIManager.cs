using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Barra")] 
    [SerializeField] private Image expPlayer;

    [Header("Texto")] 
    [SerializeField] private TextMeshProUGUI expTMP;

    private float expActual;
    private float expRequiredNewLevel;

    private void Update()
    {
        UpdateUIPlayer();
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
}
