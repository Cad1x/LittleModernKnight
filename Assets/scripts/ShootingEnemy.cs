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
    private GameObject currentBullet; // Przechowuje referencj� do aktualnie istniej�cego pocisku

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

                // Je�li istnieje poprzedni pocisk, usu� go
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
        // Tw�rz nowy pocisk
        currentBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);

        // Ustaw si�� strza�u na pocz�tkow� lub zaktualizowan� warto��
        Projectile projectileScript = currentBullet.GetComponent<Projectile>();
        if (transform.hasChanged)
        {
            projectileScript.force = updatedForce;
            // Resetuj flag� zmiany po�o�enia przeciwnika
            transform.hasChanged = false;
        }
        else
        {
            projectileScript.force = initialForce;
        }
    }

    void ClearBullets()
    {
        // Je�li istnieje poprzedni pocisk, usu� go
        if (currentBullet != null)
        {
            Destroy(currentBullet);
        }
    }
}
