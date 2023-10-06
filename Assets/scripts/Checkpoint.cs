using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = GameObject.FindObjectOfType<CheckpointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            // Aktywuj checkpoint, gdy gracz dotknie checkpointu
            checkpointManager.ActivateCheckpoint(transform.position);
        }
    }

}
