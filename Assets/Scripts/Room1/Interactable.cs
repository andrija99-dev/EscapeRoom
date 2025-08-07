using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool HideUIWhileInteracting { get; set; } = false;
    public static Interactable currentInteractable { get; private set; }

    public static void SetCurrentInteractable(Interactable interactable)
    {
        currentInteractable = interactable;
    }
    public virtual bool CanInteract(Transform playerCamera)
    {
        return true; 
    }
    public virtual void ExitUI()
    {
        return;
    }

    public abstract void Interact(); 


}