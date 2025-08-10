using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private Camera tvCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera boxCameraRoom1;
    [SerializeField] private Camera boxCameraRoom2;
    [SerializeField] private Camera boxCameraRoom3;
    [SerializeField] private Camera storyBrothersCamera;
    [SerializeField] private Camera storyCornerCamera;
    [SerializeField] private Camera storyOldestBrotherCamera;

    [Header("Hint Numbers")]
    [SerializeField] private Camera hintNumber2Camera;
    [SerializeField] private Camera hintNumber4Camera;
    [SerializeField] private Camera hintNumber5Camera;
    [SerializeField] private Camera hintNumber7Camera;


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

            case 3:
                boxCameraRoom3.enabled = true;
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

            case 3:
                boxCameraRoom3.enabled = false;
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

            case 3:
                storyOldestBrotherCamera.enabled = true;
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

            case 3:
                storyOldestBrotherCamera.enabled = false;
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

    internal void EnableHintNumberCamera(int hintNumber)
    {
        switch (hintNumber)
        {
            case 2:
                hintNumber2Camera.enabled = true;
                break;

            case 4:
                hintNumber4Camera.enabled = true;
                break;

            case 5:
                hintNumber5Camera.enabled = true;
                break;

            case 7:
                hintNumber7Camera.enabled = true;
                break;

            default:
                break;
        }
    }

    internal void DisableHintNumberCamera(int hintNumber)
    {
        switch (hintNumber)
        {
            case 2:
                hintNumber2Camera.enabled = false;
                break;

            case 4:
                hintNumber4Camera.enabled = false;
                break;

            case 5:
                hintNumber5Camera.enabled = false;
                break;

            case 7:
                hintNumber7Camera.enabled = false;
                break;

            default:
                break;
        }
    }
}