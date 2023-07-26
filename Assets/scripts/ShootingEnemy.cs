using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Transform target;
    public float minDistance;
    private GameObject player;

    public float speed;
    public int triggerDist = 5;
    private float distance;

    private float timer;
    private List<GameObject> bullets = new List<GameObject>();


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < triggerDist)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearBullets();
        }

    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        bullets.Add(newBullet);

    }
    void ClearBullets()
    {
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        bullets.Clear();
    }

}
