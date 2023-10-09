using UnityEngine;

public class ItemHolding : MonoBehaviour
{
    public float pickupRange = 0.2f;
    private GameObject pickedItem;
    private Color originalColor;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (pickedItem == null)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Item"))
                    {
                        pickedItem = collider.gameObject;

                        // Save the original color
                        originalColor = pickedItem.GetComponent<SpriteRenderer>().color;

                        // Change color to green
                        pickedItem.GetComponent<SpriteRenderer>().color = Color.green;

                        pickedItem.GetComponent<Rigidbody2D>().simulated = false;
                        pickedItem.transform.SetParent(transform);
                        break;
                    }
                }
            }
            else
            {
                // Change color back to original
                pickedItem.GetComponent<SpriteRenderer>().color = originalColor;

                pickedItem.transform.SetParent(null);
                pickedItem.GetComponent<Rigidbody2D>().simulated = true;
                pickedItem = null;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}