using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float targetYRotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AudioClip doorOpenSound;

    private Quaternion targetRotation;
    private bool isOpening = false;
    private bool hasPlayedSound = false;

    private void Start()
    {
        Vector3 currentEuler = transform.rotation.eulerAngles;
        targetRotation = Quaternion.Euler(currentEuler.x, targetYRotation, currentEuler.z);
    }

    private void Update()
    {
        if (isOpening)
        {
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
                Debug.Log("Vrata su se potpuno otvorila.");
            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
}