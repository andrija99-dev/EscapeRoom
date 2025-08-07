using UnityEngine;

public class Key : Interactable
{
    [SerializeField] private PadlockInteractable padlockInteractable;
    public override void Interact()
    {
        PlayerInventory.Instance.ObtainKey();
        Destroy(gameObject);
        padlockInteractable.ExitUI();

    }

    

}