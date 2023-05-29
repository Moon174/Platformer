using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject GameOverScreen;
    public AudioSource audioSource;
    public AudioClip gameOverMusic;
    public static bool allowPauseGame = true;
    public Button PauseButton;

    private void Awake()
    {
        isGameOver = false;
        allowPauseGame = true;
    }

    private void Update()

    {
        if (isGameOver)
        {
            GameOverScreen.SetActive(true);
            PauseButton.interactable = false;
            if (!audioSource.isPlaying)
            {
                audioSource.clip = gameOverMusic;
                audioSource.Play();
                allowPauseGame = false;
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
