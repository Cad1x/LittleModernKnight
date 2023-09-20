using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public RockScript rockColor;
    public ThrowingRock rock; // Przypisz kamieñ do tego pola w inspektorze
    private SpriteRenderer rockRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1")) // Upewnij siê, ¿e tylko gracz mo¿e podnosiæ power-up
        {
            rock.throwForce = 20; // Zmieñ si³ê rzutu kamienia
            rockRenderer = rockColor.GetComponent<SpriteRenderer>();
            rockRenderer.color = Color.black; // Zmieñ kolor kamienia
            rockColor.DMG = 3;
            // Zniszcz power-up po podniesieniu
            Destroy(gameObject);
        }
    }
}
