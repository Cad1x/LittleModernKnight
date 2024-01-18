using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{

    [SerializeField]
    float followDistance = 5f;
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public EyeChangeColor color;
    public EnemyHealth enemyHealth;
    public Transform escapePoint;

    private bool isHealing = false;
    private bool isAtEscapePoint = false;
    private float healTimer = 0f;
    private float healInterval = 2.5f;


    Path path;

    public PlayerHealth playerHealth;

    int currentWaypoint = 0;
    bool reachedEndOfPath = false;


    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

      
    }

    private void Update()
    {
        //TryHeal();

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        float distanceToTarget = Vector2.Distance(rb.position, target.position);
        if (distanceToTarget <= followDistance)
        {
            // Przeciwnik jest wystarczaj¹co blisko, aby pod¹¿aæ za nami
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);
        }
        else
        {
            // Przeciwnik jest zbyt daleko, aby pod¹¿aæ za nami
            rb.velocity = Vector2.zero;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);
        }
        else if (rb.velocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

        }

        if (playerHealth != null && playerHealth.health <= 3) 
        {
            color.zmienKolor = true;
            speed = 900;
        }
        else
        {

            color.zmienKolor = false;
            speed = 300;
            color.PoprzedniKolor();
        }

        if (escapePoint != null)
        { 
            if (enemyHealth != null && enemyHealth.currentHealth <= 4)
            {

               

                float escapeSpeed = 700;
                Vector2 escapeDirection = ((Vector2)escapePoint.position - rb.position).normalized;
                Vector2 escapeForce = escapeDirection * escapeSpeed * Time.deltaTime;

                rb.AddForce(escapeForce);

                float distanceToEscapePoint = Vector2.Distance(rb.position, escapePoint.position);
                if (distanceToEscapePoint < 0.2f)
                {
                    isAtEscapePoint = true;
                }

            }
        }
        if (isAtEscapePoint)
        {
            isHealing = true;

            healTimer += Time.deltaTime;

            if (healTimer >= healInterval)
            {
                enemyHealth.Heal(1);

                healTimer = 0f;

                if (enemyHealth.currentHealth >= enemyHealth.maxHealth)
                {
                    isHealing = false;
                    isAtEscapePoint = false;
                }
            }
        }
        else
        {
            StandardBehaviuor();
        }

    }

   void StandardBehaviuor()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        float distanceToTarget = Vector2.Distance(rb.position, target.position);
        if (distanceToTarget <= followDistance)
        {
            // Przeciwnik jest wystarczaj¹co blisko, aby pod¹¿aæ za nami
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);
        }
        else
        {
            // Przeciwnik jest zbyt daleko, aby pod¹¿aæ za nami
            rb.velocity = Vector2.zero;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);
        }
        else if (rb.velocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

        }

        if (playerHealth != null && playerHealth.health <= 3) // Zaktualizowano sprawdzenie punktów zdrowia
        {
            color.zmienKolor = true;
            speed = 900;
        }
        else
        {

            color.zmienKolor = false;
            speed = 300;
            color.PoprzedniKolor();
        }
    }


    

}



