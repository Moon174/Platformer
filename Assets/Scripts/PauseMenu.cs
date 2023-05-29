using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject SettingsMenu;
    public GameObject HelpMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
            CloseHelpMenu();
        }
    }

    public void OpenHelpMenu()
    {
        HelpMenu.SetActive(true);  
    }


        public void CloseHelpMenu()
    {
        HelpMenu.SetActive(false);
    }

    public void PauseGame()
    {
        if (GameOver.allowPauseGame)
        {
            Time.timeScale = 0f;
            isPaused = true;
            SettingsMenu.SetActive(true);
            PlayerMovement.isMoving = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
        SettingsMenu.SetActive(false);
        PlayerMovement.isMoving = true;
    }
}