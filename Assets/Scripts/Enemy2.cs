using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject projectilePrefab;  // ������ �������
    public Transform firePoint;          // �����, ������ ����� ������� ������
    public float projectileSpeed = 10f;  // �������� �������
    public float fireRate = 2f;          // ������� ��������
    public float shootingZoneRadius = 10f;
    private Transform player;            // ������ �� ������
    private float nextFireTime;          // ����� ���������� ��������
    public GameObject playersprite;
    public Transform[] waypoints;    // ������ �����, �� ������� ����� ��������� ����
    public float moveSpeed = 5f;     // �������� ����������� �����
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
            // �������� ������� �����
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;

            // ������� ����� � ������� ������� �����
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // ���� ���� ������ ������� �����, ��������� � ���������
            if (transform.position == targetPosition)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // ���� ���� ������ ��������� �����, ���������� ������ �� 0
            currentWaypointIndex = 0;
        }

    }
}