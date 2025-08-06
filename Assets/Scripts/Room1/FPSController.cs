using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseSensitivity;

    private CharacterController controller;
    private Transform cam;
    private float xRotation = 0f;
    private bool skipMouseInput = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;

        xRotation = NormalizeAngle(cam.localEulerAngles.x);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        skipMouseInput = true;
    }

    void Update()
    {
        if (InteractionManager.IsInteractingWithUI)
        {
            return;
        }

        if (skipMouseInput)
        {
            
            if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
            {
                return;
            }                

            skipMouseInput = false;
            return;  
        }

        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal"); // A/D
        float z = Input.GetAxis("Vertical");   // W/S

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotacija tela (levo-desno)
        transform.Rotate(Vector3.up * mouseX);

        // Rotacija kamere (gore-dole)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private float NormalizeAngle(float angle)
    {
        if (angle > 180f)
            angle -= 360f;
        return angle;
    }
}
