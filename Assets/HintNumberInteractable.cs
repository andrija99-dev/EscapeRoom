using UnityEngine;

public class HintNumberInteractable : Interactable
{
    [SerializeField] private int hintNumber;
    public override void Interact()
    {
        InteractionManager.SetUIInteraction(true);
        HideUIWhileInteracting = true;
        SetCurrentInteractable(this);

        CameraManager.Instance.DisableMainCamera();
        CameraManager.Instance.EnableHintNumberCamera(hintNumber);
        UIManager.Instance.ShowMessageUI("X - Exit");

    }

    public override void ExitUI()
    {
        InteractionManager.SetUIInteraction(false);
        HideUIWhileInteracting = false;

        CameraManager.Instance.EnableMainCamera();
        CameraManager.Instance.DisableHintNumberCamera(hintNumber);
        UIManager.Instance.HideMessageUI();

    }
}
