using UnityEngine;

public class LightSwitchInteractable : Interactable
{
    [SerializeField] private LightSequence lightSequence;
    [SerializeField] private AudioClip buttonClickSound;

    private bool isClicked = false;

    public override void Interact()
    {
        Click();
    }

    public override bool CanInteract(Transform interactor)
    {
        return !isClicked;
    }

    private void Click()
    {
        isClicked = true;
        lightSequence.StartSequence();
        SoundManager.Instance.PlaySFX(buttonClickSound);
    }
}
