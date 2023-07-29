using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour, IDoor
{
    private Animator animator;
    private bool isOpen = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        isOpen = true;
        animator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        isOpen = false;
        animator.SetBool("DoorOpen", false);

    }

    public void ToogleDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
}
