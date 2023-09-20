using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed;
    public Transform[] points;
    public int startingPoints;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoints].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            collision.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            collision.transform.parent = null;
        }
    }
}
