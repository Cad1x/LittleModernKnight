using System.Collections.Generic;
using UnityEngine;

public class SightEnemy : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public float speed = 2;
    public float waitTime = 1f;


    public float agroRange = 5f;
    public float chaseSpeed = 4f;

    public Transform playerTransform;

    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        if (points.Count == 0)
            return;

        Transform currentPoint = points[nextID];
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        Vector2 movement = direction * speed * Time.deltaTime;

        transform.Translate(movement);

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        float distance = Vector2.Distance(transform.position, currentPoint.position);

        if (distance < 0.1f)
        {
            nextID++;

            if (nextID >= points.Count)
                nextID = 0;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        Vector2 movement = new Vector2(direction.x, 0) * chaseSpeed * Time.deltaTime;

        transform.Translate(movement);

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }


}