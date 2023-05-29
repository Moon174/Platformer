using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
     private void Start()
     {
         if (PlayerPrefs.HasKey("SoundEnabled"))
         {
             int soundEnabled = PlayerPrefs.GetInt("SoundEnabled");

             if (soundEnabled == 1)
             {
                 SoundManager.isSoundEnabled = true;
                 AudioListener.volume = 1f;
             }
             else
             {
                 SoundManager.isSoundEnabled = false;
                 AudioListener.volume = 0f;
             }
         }
         else
         {
             SoundManager.isSoundEnabled = true;
             AudioListener.volume = 1f;
         }
     }
 
    
    public void ExitGame()
    {
        Application.Quit();
    }
}


