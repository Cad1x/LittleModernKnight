using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public float flashDuration = 0.2f; // Czas, przez który kolor bêdzie zmieniony na bia³y
    public Color flashColor = Color.white; // Kolor bia³y
    public PlayerRespawn respawn;
    private Color originalColor; // Oryginalny kolor gracza
    private SpriteRenderer playerRenderer; // Komponent Renderer

    void Start()
    {
        health = maxHealth;

        // Pobierz komponent Renderer
        playerRenderer = GetComponent<SpriteRenderer>();

        // Zapamiêtaj oryginalny kolor
        originalColor = playerRenderer.color;
    }

    void Update()
    {
        // Tu mo¿esz umieœciæ inne logiki zwi¹zane z ¿yciem gracza
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
            // Jeœli gracz otrzyma³ obra¿enia, uruchom coroutine zmiany koloru
            StartCoroutine(FlashWhite());
        }
    }

    IEnumerator FlashWhite()
    {
        // Zmieñ kolor na bia³y
        playerRenderer.color = flashColor;

        // Poczekaj przez okreœlony czas
        yield return new WaitForSeconds(flashDuration);

        // Wróæ do oryginalnego koloru
        playerRenderer.color = originalColor;
    }

    private void ResetGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        transform.position = respawn.respawnPoint;
    }
}
