using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private PadlockInteractable padlockInteractable;
    private void Update()
    {
        if (!padlockInteractable.HideUIWhileInteracting)
        {
            LightManager.Instance.EnableKeyLight();
        }
    }
}
