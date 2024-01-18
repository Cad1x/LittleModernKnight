using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 8;
    public int currentHealth;
    private Material material; 

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
            StartCoroutine(ChangeColorForSeconds(Color.red, 0.5f)); 
            Destroy(gameObject, 0.099f);
        }
        else
        {
            StartCoroutine(ChangeColorForSeconds(Color.red, 0.1f)); 
        }
    }

    IEnumerator ChangeColorForSeconds(Color color, float seconds)
    {
        material.color = color;
        yield return new WaitForSeconds(seconds);
        material.color = Color.white; 
    }
}
