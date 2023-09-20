using UnityEngine;

public class RockScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int DMG = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "WeakPoint")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(DMG);
        }

    }
}
