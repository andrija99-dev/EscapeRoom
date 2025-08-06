using UnityEngine;

public class Key : Interactable
{
    public override void Interact()
    {
        PlayerInventory.Instance.ObtainKey();
        Destroy(gameObject);
        Debug.Log("Kljuc uzet!");
    }

}