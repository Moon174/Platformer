using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform target1; // ������ �������, ���� ��������� ������ �������������
    public Transform target2; // ������ �������, ���� ��������� ������ �������������
    public float moveSpeed = 1f; // �������� ����������� ���������

    private Transform currentTarget; // ������� ������� ������� ���������

    private void Start()
    {
        // ��������� ������� ��������� - target1
        currentTarget = target1;
    }

    private void FixedUpdate()
    {
        // ����������� ��������� ����� ����� �������� ���������
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.fixedDeltaTime);

        // ���� ��������� �������� ����� �� ������� �������, ������ ������� ������� ������� �� ������
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.05f)
        {
            if (currentTarget == target1)
                currentTarget = target2;
            else
                currentTarget = target1;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ������ ��������� ������������ �������� ���������, ����� �� ����������� ������ � ���
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.transform.SetParent(null);
        }
    }

}


