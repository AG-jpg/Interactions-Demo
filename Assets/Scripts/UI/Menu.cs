using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject pausePanel;
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
            pausePanel.SetActive(true);
            bg.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            bg.SetActive(false);
        }
    }
}
