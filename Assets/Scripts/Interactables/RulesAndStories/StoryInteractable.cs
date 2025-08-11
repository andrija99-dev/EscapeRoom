using UnityEngine;

public class StoryInteractable : Interactable
{

    public override void Interact()
    {
        InteractionManager.SetUIInteraction(true);
        HideUIWhileInteracting = true;
        SetCurrentInteractable(this);

        CameraManager.Instance.DisableMainCamera();
        CameraManager.Instance.EnableStoryCamera(InteractionManager.CurrentRoom);
        LightManager.Instance.EnableStoryLight(InteractionManager.CurrentRoom);
        UIManager.Instance.ShowMessageUI("X - Exit");
        HintManager.Instance.MarkClueFound(InteractionManager.CurrentRoom, 0);


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
        CameraManager.Instance.DisableStoryCamera(InteractionManager.CurrentRoom);
        LightManager.Instance.DisableStoryLight(InteractionManager.CurrentRoom);
        UIManager.Instance.HideMessageUI();

    }
}
