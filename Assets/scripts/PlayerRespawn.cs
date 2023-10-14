using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;

    private void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            transform.position = respawnPoint;
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }



}