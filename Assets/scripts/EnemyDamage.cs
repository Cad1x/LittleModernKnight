using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 2;
    public float damageInterval = 1f;

    private bool isPlayerInContact = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DamagePlayerRoutine());
    }

    IEnumerator DamagePlayerRoutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => isPlayerInContact); // Czekaj, a¿ gracz wejdzie w kontakt z przeciwnikiem
            playerHealth.TakeDamage(damage);
            yield return new WaitForSeconds(damageInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            isPlayerInContact = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            isPlayerInContact = false;
        }
    }
}
