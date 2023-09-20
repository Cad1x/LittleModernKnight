using UnityEngine;

public class itemCollector : MonoBehaviour
{

    public int value;
    public CoinCounter coinCounter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Upgrade"))
        {
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinCounter.currentCoins++;

        }
    }

}
