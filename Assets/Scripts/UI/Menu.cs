using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject AppPanel;
    public GameObject bg;
    public static bool gameIsPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(!pausePanel.activeSelf);
            bg.SetActive(!bg.activeSelf);
            AppPanel.SetActive(!AppPanel.activeSelf);
        }
        else
        {
            ExitPanels();
        }
    }

    public void ExitPanels()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(!pausePanel.activeSelf);
        bg.SetActive(!bg.activeSelf);
        AppPanel.SetActive(!AppPanel.activeSelf);
    }
}
