using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public RockScript rockColor;
    public ThrowingRock rock; // Przypisz kamie� do tego pola w inspektorze
    private SpriteRenderer rockRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1")) // Upewnij si�, �e tylko gracz mo�e podnosi� power-up
        {
            rock.throwForce = 20; // Zmie� si�� rzutu kamienia
            rockRenderer = rockColor.GetComponent<SpriteRenderer>();
            rockRenderer.color = Color.black; // Zmie� kolor kamienia
            rockColor.DMG = 3;
            // Zniszcz power-up po podniesieniu
            Destroy(gameObject);
        }
    }
}
