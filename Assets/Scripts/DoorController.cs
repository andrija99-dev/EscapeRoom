using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float targetYRotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AudioClip doorOpenSound;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isOpening = false;
    private bool isClosing = false;
    private bool hasOpened = false;
    private bool hasPlayedSound = false;

    private void Start()
    {
        initialRotation = transform.rotation;
        Vector3 currentEuler = transform.rotation.eulerAngles;
        targetRotation = Quaternion.Euler(currentEuler.x, targetYRotation, currentEuler.z);
    }

    private void Update()
    {
        if (isOpening)
        {
            PlayerInventory.Instance.DestroyKey();
            if (!hasPlayedSound)
            {
                SoundManager.Instance.PlaySFX(doorOpenSound);
                hasPlayedSound = true;
            }

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isOpening = false;
                hasPlayedSound = false;
                InteractionManager.GoToNextRoom();
            }
        }
        else if (isClosing)
        {
            if (!hasPlayedSound)
            {
                SoundManager.Instance.PlaySFX(doorOpenSound);
                hasPlayedSound = true;
            }

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                initialRotation,
                rotationSpeed * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, initialRotation) < 0.1f)
            {
                isClosing = false;
                hasPlayedSound = false;
            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }

    public void CloseDoor()
    {
        isClosing = true;
    }
}