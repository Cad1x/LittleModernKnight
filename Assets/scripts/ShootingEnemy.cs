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
    private GameObject currentBullet; // Przechowuje referencjê do aktualnie istniej¹cego pocisku

    private float initialForce = 20f;
    private float updatedForce = 5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1");
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, triggerDist);

        if (hit.collider != null && hit.collider.CompareTag("Player1"))
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;

                // Jeœli istnieje poprzedni pocisk, usuñ go
                if (currentBullet != null)
                {
                    Destroy(currentBullet);
                }

                // Strzelaj nowym pociskiem
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
        // Twórz nowy pocisk
        currentBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);

        // Ustaw si³ê strza³u na pocz¹tkow¹ lub zaktualizowan¹ wartoœæ
        Projectile projectileScript = currentBullet.GetComponent<Projectile>();
        if (transform.hasChanged)
        {
            projectileScript.force = updatedForce;
            // Resetuj flagê zmiany po³o¿enia przeciwnika
            transform.hasChanged = false;
        }
        else
        {
            projectileScript.force = initialForce;
        }
    }

    void ClearBullets()
    {
        // Jeœli istnieje poprzedni pocisk, usuñ go
        if (currentBullet != null)
        {
            Destroy(currentBullet);
        }
    }
}
