using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera boxCamera;
    [SerializeField] private Camera storyCamera;
    [SerializeField] private Camera tvCamera;

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

    internal void EnableStoryCamera()
    {
        storyCamera.enabled = true;
    }

    internal void DisableStoryCamera()
    {
        storyCamera.enabled = false;
    }

    internal void EnableTvCamera()
    {
        tvCamera.enabled = true;
    }

    internal void DisableTvCamera()
    {
        tvCamera.enabled = false;
    }
}