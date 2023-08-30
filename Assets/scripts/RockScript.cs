using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "WeakPoint")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }

    }
}
