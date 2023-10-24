using System.Collections;
using UnityEngine;

public class AstarDMGENEMY : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red; // Kolor po zetkniêciu

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
        // Zmiana koloru na kolor po zetkniêciu
        spriteRenderer.color = hitColor;

        // Poczekaj przez okreœlony czas
        yield return new WaitForSeconds(0.1f); // æwieræ sekundy

        // Przywróæ oryginalny kolor
        spriteRenderer.color = Color.white; // lub inny kolor, który chcesz ustawiæ
    }
}
