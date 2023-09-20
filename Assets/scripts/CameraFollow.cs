using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Transform gracza, za którym ma pod¹¿aæ kamera
    public float smoothSpeed = 0.125f; // Wartoœæ opóŸnienia poruszania kamery

    private Vector3 offset;

    private void Start()
    {
        // Oblicz pocz¹tkowe przesuniêcie miêdzy kamer¹ a graczem
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Oblicz docelow¹ pozycjê kamery
        Vector3 desiredPosition = target.position + offset;

        // Wyg³adŸ ruch kamery, u¿ywaj¹c metody Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Ustaw pozycjê kamery na wyg³adzon¹ pozycjê
        transform.position = smoothedPosition;
    }
}