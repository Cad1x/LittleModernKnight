using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Color greenColor = Color.green; // Kolor zielony do ustawienia w inspektorze

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            // Oznacz checkpoint jako aktualny checkpoint gracza
            // PlayerRespawn.SetCheckpoint(transform.position);

            // Zmiana koloru na zielony
            ChangeColorToGreen();
        }
    }

    public void ChangeColorToGreen()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Zmieñ kolor sprite'a na zielony
            spriteRenderer.color = greenColor;
        }


    }




}
