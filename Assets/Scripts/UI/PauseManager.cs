using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsPanel;

    private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void ReturnToMain()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
