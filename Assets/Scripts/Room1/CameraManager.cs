using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera boxCamera;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
                                                                            
    public void EnableMainCamera()
    {
        mainCamera.enabled = true;
    }
    public void DisableMainCamera()
    {
        mainCamera.enabled = false;
    }
    public void EnableBoxCamera()
    {
        boxCamera.enabled = true;
    }
    public void DisableBoxCamera()
    {
        boxCamera.enabled = false;
    }
}