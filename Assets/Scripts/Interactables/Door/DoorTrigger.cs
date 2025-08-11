using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController door;
    private bool hasClosed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasClosed && other.CompareTag("Player"))
        {
            door.CloseDoor();
            hasClosed = true;  
        }
    }

}
