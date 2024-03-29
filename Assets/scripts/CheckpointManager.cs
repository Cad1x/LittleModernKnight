using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 lastCheckpointPosition; // Pozycja ostatniego aktywowanego checkpointu

    // Funkcja aktywująca checkpoint
    public void ActivateCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition;
    }

    // Funkcja przywracająca gracza do ostatniego aktywowanego checkpointu
    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = lastCheckpointPosition;
    }
}
