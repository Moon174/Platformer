using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform target1; // Первая позиция, куда платформа должна переместиться
    public Transform target2; // Вторая позиция, куда платформа должна переместиться
    public float moveSpeed = 1f; // Скорость перемещения платформы

    private Transform currentTarget; // Текущая целевая позиция платформы

    private void Start()
    {
        // Начальная позиция платформы - target1
        currentTarget = target1;
    }

    private void FixedUpdate()
    {
        // Перемещение платформы между двумя целевыми позициями
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.fixedDeltaTime);

        // Если платформа достигла одной из целевых позиций, меняем текущую целевую позицию на другую
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
            // Делаем платформу родительским объектом персонажа, чтобы он перемещался вместе с ней
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


