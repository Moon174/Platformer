using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;
    private Transform target;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = pointA;
    }

    private void Update()
    {
        // ������������ � ������� ������� �����
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // ���� �������� ������� ������� �����, ������ �� �� ���������������
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            if (target == pointA)
                target = pointB;
            else
                target = pointA;
        }
        FlipSprite();
    }

    private void FlipSprite()
    {
        // ���������� ����������� ��������
        Vector2 direction = target.position - transform.position;

        if (direction.x < 0)
            spriteRenderer.flipX = true;
        else if (direction.x > 0)
            spriteRenderer.flipX = false;
    }

}


