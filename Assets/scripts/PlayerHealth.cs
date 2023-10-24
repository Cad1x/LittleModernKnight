using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public float flashDuration = 0.2f; // Czas, przez kt�ry kolor b�dzie zmieniony na bia�y
    public Color flashColor = Color.white; // Kolor bia�y
    public PlayerRespawn respawn;
    private Color originalColor; // Oryginalny kolor gracza
    private SpriteRenderer playerRenderer; // Komponent Renderer

    void Start()
    {
        health = maxHealth;

        // Pobierz komponent Renderer
        playerRenderer = GetComponent<SpriteRenderer>();

        // Zapami�taj oryginalny kolor
        originalColor = playerRenderer.color;
    }

    void Update()
    {
        // Tu mo�esz umie�ci� inne logiki zwi�zane z �yciem gracza
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject, 0.2f);
            ResetGame();
        }
        else
        {
            // Je�li gracz otrzyma� obra�enia, uruchom coroutine zmiany koloru
            StartCoroutine(FlashWhite());
        }
    }

    IEnumerator FlashWhite()
    {
        // Zmie� kolor na bia�y
        playerRenderer.color = flashColor;

        // Poczekaj przez okre�lony czas
        yield return new WaitForSeconds(flashDuration);

        // Wr�� do oryginalnego koloru
        playerRenderer.color = originalColor;
    }

    private void ResetGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        transform.position = respawn.respawnPoint;
    }
}
