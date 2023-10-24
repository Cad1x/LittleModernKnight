using System.Collections;
using UnityEngine;

public class AstarDMGENEMY : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red; // Kolor po zetkni�ciu

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            StartCoroutine(BlinkEffect());
        }
    }

    private IEnumerator BlinkEffect()
    {
        // Zmiana koloru na kolor po zetkni�ciu
        spriteRenderer.color = hitColor;

        // Poczekaj przez okre�lony czas
        yield return new WaitForSeconds(0.1f); // �wier� sekundy

        // Przywr�� oryginalny kolor
        spriteRenderer.color = Color.white; // lub inny kolor, kt�ry chcesz ustawi�
    }
}
