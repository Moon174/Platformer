using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealthValue = 3;
    public int healthValue = 3;

    public Image healthImage;
    public Sprite fullHealthSprite;
    public Sprite mediumHealthSprite;
    public Sprite lowHealthSprite;
    public Sprite NoHealthSprite;

    public AudioSource levelMusic;


   
    private void HealthStatus()
    {

        if (healthValue == 3)
        {
            healthImage.sprite = fullHealthSprite;
        }
        else if (healthValue == 2)
        {
            healthImage.sprite = mediumHealthSprite;
        }
        else if (healthValue == 1)
        {
            healthImage.sprite = lowHealthSprite;
        }

        if (healthValue == 0)
        {
            healthImage.sprite = NoHealthSprite;
            gameObject.SetActive(false);
            GameOver.isGameOver = true;
            levelMusic.Stop();
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            healthValue -= 1;
            HealthStatus();
            StartCoroutine(TakeDamage());
        }

        if (collision.gameObject.CompareTag("OneShot"))
        {
            healthValue = 0;
            Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            healthValue += 1;
            HealthStatus();
        }

        if (collision.gameObject.CompareTag("EnemyFire"))
        {
            healthValue -= 1;
            HealthStatus();
            StartCoroutine(TakeDamage());
        }

        if (healthValue > maxHealthValue)
        {
            healthValue = maxHealthValue;
        }
    }

    private void Update()
    {
        HealthStatus();
    }


    public void BackToMenu()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        PlayerMovement.isMoving = true;
    }

    IEnumerator TakeDamage()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
    }
}   
