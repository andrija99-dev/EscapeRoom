using UnityEngine;

public class PadlockInteractable : Interactable
{
    [SerializeField] private PadlockController padlock;
    

    

    public override void Interact()
    {
        InteractionManager.SetUIInteraction(true);
        padlock.ResetSelectedRing();
        HideUIWhileInteracting = true;
        SetCurrentInteractable(this);

        CameraManager.Instance.DisableMainCamera();
        CameraManager.Instance.EnableBoxCamera();
        LightManager.Instance.EnableBoxLight();
        UIManager.Instance.ShowBoxUI();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public override bool CanInteract(Transform cam)
    {
        Vector3 directionToPlayer = (cam.position - transform.position).normalized;
        float angle = Vector3.Angle(cam.forward, (transform.position - cam.position).normalized);
        return angle < 45f;
    }
    public override void ExitUI()
    {
        InteractionManager.SetUIInteraction(false);
        padlock.ResetSelectedRing();
        HideUIWhileInteracting = false;

        CameraManager.Instance.EnableMainCamera();
        CameraManager.Instance.DisableBoxCamera();
        LightManager.Instance.DisableBoxLight();
        UIManager.Instance.HideBoxUI();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}