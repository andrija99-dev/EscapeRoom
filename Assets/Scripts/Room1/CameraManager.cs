using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera boxCameraRoom1;
    [SerializeField] private Camera storyBrothersCamera;
    [SerializeField] private Camera storyCornerCamera;
    [SerializeField] private Camera secondRuleCamera;
    [SerializeField] private Camera tvCamera;
    [SerializeField] private Camera boxCameraRoom2;

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
    public void EnableBoxCamera(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                boxCameraRoom1.enabled = true;
                break;

            case 2:
                boxCameraRoom2.enabled = true;
                break;

            default:
                break;
        }
    }
    public void DisableBoxCamera(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                boxCameraRoom1.enabled = false;
                break;

            case 2:
                boxCameraRoom2.enabled = false;
                break;

            default:
                break;
        }
    }

    public void EnableStoryCamera(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                storyBrothersCamera.enabled = true;
                break;

            case 2:
                storyCornerCamera.enabled = true;
                break;

            default:
                break;
        }
    }

    public void DisableStoryCamera(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                storyBrothersCamera.enabled = false;
                break;

            case 2:
                storyCornerCamera.enabled = false;
                break;

            default:
                break;
        }
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