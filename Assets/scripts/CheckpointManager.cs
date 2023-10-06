using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 lastCheckpointPosition; // Pozycja ostatniego aktywowanego checkpointu

    // Funkcja aktywuj�ca checkpoint
    public void ActivateCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition;
    }

    // Funkcja przywracaj�ca gracza do ostatniego aktywowanego checkpointu
    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = lastCheckpointPosition;
    }
}
