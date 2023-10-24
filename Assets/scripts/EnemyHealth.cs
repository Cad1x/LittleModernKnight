using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 8;
    public int currentHealth;
    private Material material; // Materia³ obiektu, aby móc zmieniaæ kolor

    void Start()
    {
        currentHealth = maxHealth;
        material = GetComponent<Renderer>().material;
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            StartCoroutine(ChangeColorForSeconds(Color.red, 0.5f)); // Zmiana koloru na czerwony przez 0.5 sekundy
            Destroy(gameObject, 0.099f); // Zniszcz obiekt po 0.5 sekundy
        }
        else
        {
            StartCoroutine(ChangeColorForSeconds(Color.red, 0.1f)); // Zmiana koloru na czerwony przez 0.1 sekundy po otrzymaniu obra¿eñ
        }
    }

    IEnumerator ChangeColorForSeconds(Color color, float seconds)
    {
        material.color = color;
        yield return new WaitForSeconds(seconds);
        material.color = Color.white; // Powrót do koloru bia³ego
    }
}
