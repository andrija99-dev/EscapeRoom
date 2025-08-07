using UnityEngine;

public class StoryInteractable : Interactable
{

    public override void Interact()
    {
        InteractionManager.SetUIInteraction(true);
        HideUIWhileInteracting = true;
        SetCurrentInteractable(this);

        CameraManager.Instance.DisableMainCamera();
        CameraManager.Instance.EnableStoryCamera();
        LightManager.Instance.EnableStoryLight();
        UIManager.Instance.ShowMessageUI("Esc - Exit");

    }

    public override bool CanInteract(Transform playerCamera)
    {
        return Vector3.Distance(playerCamera.position, transform.position) <= 1.5f;
    }

    public override void ExitUI()
    {
        InteractionManager.SetUIInteraction(false);
        HideUIWhileInteracting = false;

        CameraManager.Instance.EnableMainCamera();
        CameraManager.Instance.DisableStoryCamera();
        LightManager.Instance.DisableStoryLight();
        UIManager.Instance.HideMessageUI();

    }
}
