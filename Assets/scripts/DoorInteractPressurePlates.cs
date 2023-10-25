using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractPressurePlates : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;
    private float timer;

    private Renderer renderer; // Dodany Renderer

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
        renderer = GetComponent<Renderer>(); // Inicjalizacja komponentu Renderer
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                door.CloseDoor();
                SetColor(Color.white); // Po zamkniêciu drzwi, przywróæ domyœlny kolor
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            door.OpenDoor();
            timer = 1f;
            SetColor(Color.green); // Zmieñ kolor na zielony po otwarciu drzwi
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            timer = 1f;
        }
    }

    private void SetColor(Color color)
    {
        // Ustaw kolor obiektu
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
