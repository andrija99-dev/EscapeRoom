using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool HideUIWhileInteracting { get; set; } = false;

    public virtual bool CanInteract(Transform playerCamera)
    {
        return true; 
    }

    public abstract void Interact(); 


}