using UnityEngine;

public class PadlockInteractable : Interactable
{
    [SerializeField] private PadlockController padlock;

    public override void Interact()
    {
        InteractionManager.SetUIInteraction(true);
        padlock.ResetSelectedRing();
        SetCurrentInteractable(this);
        HideUIWhileInteracting = true;

        CameraManager.Instance.DisableMainCamera();
        CameraManager.Instance.EnableBoxCamera(InteractionManager.CurrentRoom);
        LightManager.Instance.EnableBoxLight(InteractionManager.CurrentRoom);
        UIManager.Instance.ShowBoxUI(InteractionManager.CurrentRoom);

        if(InteractionManager.CurrentRoom == 1)
        {
            HintManager.Instance.MarkClueFound(InteractionManager.CurrentRoom, 3);
        }


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
        CameraManager.Instance.DisableBoxCamera(InteractionManager.CurrentRoom);
        LightManager.Instance.DisableBoxLight(InteractionManager.CurrentRoom);
        UIManager.Instance.HideBoxUI(InteractionManager.CurrentRoom);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}