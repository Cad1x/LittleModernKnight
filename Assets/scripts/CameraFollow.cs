using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Transform gracza, za kt�rym ma pod��a� kamera
    public float smoothSpeed = 0.125f; // Warto�� op�nienia poruszania kamery

    private Vector3 offset;

    private void Start()
    {
        // Oblicz pocz�tkowe przesuni�cie mi�dzy kamer� a graczem
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Oblicz docelow� pozycj� kamery
        Vector3 desiredPosition = target.position + offset;

        // Wyg�ad� ruch kamery, u�ywaj�c metody Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Ustaw pozycj� kamery na wyg�adzon� pozycj�
        transform.position = smoothedPosition;
    }
}