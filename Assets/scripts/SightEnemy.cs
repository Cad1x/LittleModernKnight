using System.Collections.Generic;
using UnityEngine;

public class SightEnemy : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public float speed = 2;
    public float chaseSpeed = 5;
    public float waitTime = 1f;
    bool isWaiting = false;
    float waitTimer = 0f;

    public float detectionRange = 5f;
    public LayerMask playerLayer;

    bool Idle = false;

    private Animator animator;
    private Transform player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag("Player1").transform;
    }

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        //Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root object
        GameObject root = new GameObject(name + "_Root");
        //Reset Position of Root to enemy object
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //Create Waypoints object
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints position to root        
        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Create two points (gameobject) and reset their position to waypoints objects
        //Make the points children of waypoint object
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //Init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);


    }

    private void Update()
    {
        if (!isWaiting)
        {
            if (IsPlayerInDetectionRange())
            {
                FollowPlayer();
                speed = chaseSpeed;
            }
            else
            {
                MoveToNextPoint();
                speed = 2;
            }
        }
        else
        {
            waitTimer += Time.deltaTime;
            animator.SetBool("Idle", true);

            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;
                MoveToNextPoint();
                animator.SetBool("Idle", false);
            }
        }
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy transform to look into the point's direction
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            //Check if we are at the end of the line (make the change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if we are at the start of the line (make the change +1)
            if (nextID == 0)
                idChangeValue = 1;

            isWaiting = true;
            nextID += idChangeValue;
        }
    }

    bool IsPlayerInDetectionRange()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        return distanceToPlayer <= detectionRange;
    }

    void FollowPlayer()
    {
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}