using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{


    public GameObject hiddenBlock; // Przypisz blok, który ma siê pojawiæ po kolizji z tagiem "Rock"
    private SpriteRenderer buttonRenderer;
    private Color originalColor;
    private bool isHiddenBlockActive = false;
    public float opoznienie = 4f;


    private void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
        originalColor = buttonRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock") && !isHiddenBlockActive)
        {
            isHiddenBlockActive = true;
            hiddenBlock.SetActive(true); // Po kolizji z "Rock", aktywuj ukrywany blok
            buttonRenderer.color = Color.green;
            StartCoroutine(DeactivateHiddenBlockAfterDelay(opoznienie));
        }
    }

    private IEnumerator DeactivateHiddenBlockAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isHiddenBlockActive = false;
        hiddenBlock.SetActive(false);
        buttonRenderer.color = originalColor;
    }

}
