using UnityEngine;

public class LockInteractionUI : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject buttonTextUI;
    [SerializeField] private GameObject surveillanceSystem;

    public void SetUIActive(bool active)
    {
        mainCamera.enabled = !active;
        
        surveillanceSystem.SetActive(active);
        buttonTextUI.SetActive(active);

        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }
}
