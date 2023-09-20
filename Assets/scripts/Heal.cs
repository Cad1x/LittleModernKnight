using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerHealth health;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            Destroy(gameObject);
            Healing(10);

        }
    }

    public void Healing(int amount)
    {
        health.health += amount;
        if (health.health > health.maxHealth)
        {
            health.health = health.maxHealth;
        }
    }
}
