using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isGamePaused = false;

    private Gun gunScript;

    public GameObject gun;


    private void Start()
    {
        gunScript = gun.GetComponent<Gun>();
    }
    
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
            gunScript.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            gunScript.enabled = true;
        }
    }

    public void ReturnToMain()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        gunScript.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
