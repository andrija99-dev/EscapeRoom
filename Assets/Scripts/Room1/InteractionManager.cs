using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance;
    [SerializeField] private string layerMask;

    [SerializeField] private GameObject[] rulesInspector;
    public static GameObject[] rules;

    private Interactable currentTarget;

    public static bool IsInteractingWithUI { get; private set; }
    public static int CurrentRoom { get; private set; } = 1;
    private void Awake()
    {
        rules = rulesInspector;
    }
    void Update()
    {
        HandleRaycast();

        if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            currentTarget.Interact();
        }
        if (IsInteractingWithUI && Input.GetKeyDown(KeyCode.X))
        {

            Interactable.currentInteractable.ExitUI();
            Interactable.SetCurrentInteractable(null);
        }
    }

    void HandleRaycast()
    {
        currentTarget = null;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            if (LayerMask.LayerToName(hit.collider.gameObject.layer) != layerMask)
            {
                UIManager.Instance.HideInteractionUI();
                return;
            }

            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null && interactable.CanInteract(playerCamera.transform))
            {
                
                currentTarget = interactable;

                if (interactable.HideUIWhileInteracting)
                    UIManager.Instance.HideInteractionUI();
                else
                    UIManager.Instance.ShowInteractionUI();

                return;
            }
        }

        UIManager.Instance.HideInteractionUI();
    }

    public static void SetUIInteraction(bool active)
    {
        IsInteractingWithUI = active;
    }

    public static void GoToNextRoom()
    {
        Debug.Log($"Trenutni broj sobe pre pomeranja: {CurrentRoom}");
        rules[CurrentRoom - 1].layer = LayerMask.NameToLayer("Default");
        CurrentRoom++;
        Debug.Log($"Trenutni broj sobe POSLE pomeranja: {CurrentRoom}");

    }
}