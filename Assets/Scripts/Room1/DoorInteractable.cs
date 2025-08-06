using UnityEngine;

public class Door : Interactable
{
    private bool isOpen = false;

    public override void Interact()
    {
        
        OpenDoor();
        
    }

    public override bool CanInteract(Transform interactor)
    {
        return PlayerInventory.Instance.HasKey && !isOpen;
    }

    private void OpenDoor()
    {
        isOpen = true;
        // Animacija, rotacija, itd.
        Debug.Log("Vrata su otvorena!");
    }
}