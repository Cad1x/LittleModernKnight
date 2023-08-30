using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            // Zniszcz ten obiekt po zetkniêciu z obiektem o tagu "Rock"
            Destroy(gameObject);
        }
    }
}
