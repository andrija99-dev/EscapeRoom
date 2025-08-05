using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera lockCamera;
    [SerializeField] private GameObject buttonTextUI;
    [SerializeField] private PadlockController padlockController;


    [Header("Lights")]
    [SerializeField] private Light boxLight;

    private bool isInteractingWithLock = false;
    private void Awake()
    {
        padlockController = GameObject.FindGameObjectWithTag("Padlock").GetComponent<PadlockController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // TODO: Add if statement that presents wheter a player is close to the box
            ToggleLockInteraction();
        }
    }

    private void ToggleLockInteraction()
    {
        padlockController.selectedRing = 0;
        isInteractingWithLock = !isInteractingWithLock;

        mainCamera.enabled = !isInteractingWithLock;
        lockCamera.enabled = isInteractingWithLock;
        boxLight.enabled = isInteractingWithLock;
        buttonTextUI.SetActive(isInteractingWithLock);

        Cursor.lockState = isInteractingWithLock ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isInteractingWithLock;
    }
}