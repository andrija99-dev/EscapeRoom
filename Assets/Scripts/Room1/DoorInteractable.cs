using UnityEngine;

public class Door : Interactable
{
    private bool isOpen = false;
    private DoorController doorController;   


    private void Awake()
    {
        doorController = GetComponent<DoorController>();        
    }
    public override void Interact()
    {
        isOpen = true;
        doorController.OpenDoor();

    }

    public override bool CanInteract(Transform interactor)
    {
        return PlayerInventory.Instance.HasKey && !isOpen;
    }
    
}