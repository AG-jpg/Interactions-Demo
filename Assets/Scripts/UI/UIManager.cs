using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Barra")] 
    [SerializeField] private Image expPlayer;

    [Header("Texto")] 
    [SerializeField] private Text expTMP;

    private float expActual;
    private float expRequiredNewLevel;

    private void UpdatePlayer()
    {
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount,
        expActual / expRequiredNewLevel, 10f * Time.deltaTime);

        expTMP.text = $"{expActual}/{expRequiredNewLevel}";
    }

    public void UpdateExpPlayer(float pExpActual, float pExpReq)
    {
        expActual = pExpActual;
        expRequiredNewLevel = pExpReq;
    }
}
