using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

}