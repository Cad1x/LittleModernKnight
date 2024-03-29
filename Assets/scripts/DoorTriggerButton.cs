using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorAnimation door;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            door.OpenDoor();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            door.CloseDoor();
        }

    }
}

