using UnityEngine;

public class TvInteractable : Interactable
{
    public override void Interact()
    {
        InteractionManager.SetUIInteraction(true);
        HideUIWhileInteracting = true;
        SetCurrentInteractable(this);

        CameraManager.Instance.DisableMainCamera();
        CameraManager.Instance.EnableTvCamera();
        UIManager.Instance.ShowMessageUI("Esc - Exit");

    }



    public override void ExitUI()
    {
        InteractionManager.SetUIInteraction(false);
        HideUIWhileInteracting = false;

        CameraManager.Instance.EnableMainCamera();
        CameraManager.Instance.DisableTvCamera();
        UIManager.Instance.HideMessageUI();

    }
}
