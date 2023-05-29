using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject projectilePrefab;  // Префаб снаряда
    public Transform firePoint;          // Точка, откуда будет выпущен снаряд
    public float projectileSpeed = 10f;  // Скорость снаряда
    public float fireRate = 2f;          // Частота стрельбы
    public float shootingZoneRadius = 10f;
    private Transform player;            // Ссылка на игрока
    private float nextFireTime;          // Время следующего выстрела
    public GameObject playersprite;
    public Transform[] waypoints;    // Массив точек, по которым будет двигаться враг
    public float moveSpeed = 5f;     // Скорость перемещения врага
    private int currentWaypointIndex;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time;
        currentWaypointIndex = 0;
        transform.position = waypoints[currentWaypointIndex].position;
    }

    private void Update()
    {
        if (playersprite.activeSelf)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= shootingZoneRadius)
            {
                if (Time.time >= nextFireTime)
                {
                    Vector2 direction = player.position - transform.position;
                    direction.Normalize();

                    GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    rb.velocity = direction * projectileSpeed;

                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
        }

        if (currentWaypointIndex < waypoints.Length)
        {
            // Получаем текущую точку
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;

            // Двигаем врага в сторону текущей точки
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Если враг достиг текущей точки, переходим к следующей
            if (transform.position == targetPosition)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // Если враг достиг последней точки, сбрасываем индекс до 0
            currentWaypointIndex = 0;
        }

    }
}