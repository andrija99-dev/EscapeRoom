using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController door;
    private bool hasClosed = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Usao sam u triggerEnter");
        if (!hasClosed && other.CompareTag("Player"))
        {
            door.CloseDoor();
            hasClosed = true;  
        }
    }

}
