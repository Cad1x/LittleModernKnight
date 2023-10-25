using UnityEngine;

public class PresurePlateChangeColor : MonoBehaviour
{
    [SerializeField] private Color collisionColor = Color.green; // Kolor po kolizji

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            ChangeObjectColor();
        }
    }

    private void ChangeObjectColor()
    {
        // Upewnij siê, ¿e obiekt posiada komponent Renderer
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = collisionColor;
        }
        else
        {
            Debug.LogError("Brak komponentu Renderer na obiekcie!");
        }
    }
}
