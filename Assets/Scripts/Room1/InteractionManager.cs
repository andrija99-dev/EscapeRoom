using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance = 1.5f;
    [SerializeField] private LayerMask interactableMask;

    private Interactable currentTarget;

    public static bool IsInteractingWithUI { get; private set; }

    void Update()
    {
        HandleRaycast();

        if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            currentTarget.Interact();
        }
        if (IsInteractingWithUI && Input.GetKeyDown(KeyCode.Escape))
        {

            Interactable.currentInteractable.ExitUI();
            Interactable.SetCurrentInteractable(null);
        }
    }

    void HandleRaycast()
    {
        currentTarget = null;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableMask))
        {            
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null && interactable.CanInteract(playerCamera.transform))
            {
                
                currentTarget = interactable;

                // Ako NE treba da se prikazuje UI, sakrij ga
                if (interactable.HideUIWhileInteracting)
                    UIManager.Instance.HideInteractionUI();
                else
                    UIManager.Instance.ShowInteractionUI();

                return;
            }
        }

        // Ako ništa nije pogodio, ili nije Interactable, sakrij UI
        UIManager.Instance.HideInteractionUI();
    }

    public static void SetUIInteraction(bool active)
    {
        IsInteractingWithUI = active;
    }
}