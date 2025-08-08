using System;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance;

    [SerializeField] private Light boxLightRoom1;
    [SerializeField] private Light boxLightRoom2;
    [SerializeField] private Light storyBrothersLight;
    [SerializeField] private Light storyCornerLight;
    [SerializeField] private Light keyLightRoom1;
    [SerializeField] private Light keyLightRoom2;
    [SerializeField] private Light doorLightRoom1;
    [SerializeField] private Light doorLightRoom2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void EnableBoxLight(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                boxLightRoom1.enabled = true;
                break;
            case 2:
                boxLightRoom2.enabled = true;
                break;
            default:
                break;
        }

    }

    public void DisableBoxLight(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                boxLightRoom1.enabled = false;
                break;
            case 2:
                boxLightRoom2.enabled = false;
                break;
            default:
                break;
        }
    }

    public void EnableStoryLight(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                storyBrothersLight.enabled = true;
                break;
            case 2:
                storyCornerLight.enabled = true;
                break;
            default:
                break;
        }
    }

    public void DisableStoryLight(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                storyBrothersLight.enabled = false;
                break;
            case 2:
                storyCornerLight.enabled = false;
                break;
            default:
                break;
        }
    }   

    public void EnableKeyLight(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                keyLightRoom1.enabled = true;
                break;
            case 2:
                keyLightRoom2.enabled = true;
                break;
            default:
                break;
        }
    }
    public void EnableDoorLight(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                doorLightRoom1.enabled = true;
                break;
            case 2:
                doorLightRoom2.enabled = true;
                break;
            default:
                break;
        }
    }
}