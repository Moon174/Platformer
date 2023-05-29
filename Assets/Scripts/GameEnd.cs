using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{ 
    public GameObject gameEndWindow;
    public Animator anim;
    private enum MovementStatus { stay }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) 
        {
            ShowGameEndWindow();
            GameOver.allowPauseGame = false;
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
        }


    }

    private void ShowGameEndWindow()
    {
        gameEndWindow.SetActive(true); 
    }

}
