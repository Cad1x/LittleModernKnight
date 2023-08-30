using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractPressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;
    private float timer;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }
    private void Update()
    {
        if (timer >  0)
        {
            timer-= Time.deltaTime;
            if (timer <=0f)
            {
                door.CloseDoor();
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<playerMovement>() != null)
    //    {
    //        door.OpenDoor();
    //        timer = 1f;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<playerMovement>() != null)
    //    {
    //        timer = 1f;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || collision.CompareTag("Player1"))
        {
            door.OpenDoor();
            timer = 0.1f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || collision.CompareTag("Player1"))
        {
            timer = 0.1f;
        }
    }


}
