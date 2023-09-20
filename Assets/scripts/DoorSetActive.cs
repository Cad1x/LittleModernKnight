using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    private bool isOpen = false;
    public void OpenDoor()
    {
        gameObject.SetActive(false);

    }
    public void CloseDoor()
    {
        gameObject.SetActive(true);

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
