using System;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance;

    [SerializeField] private Light boxLight;
    [SerializeField] private Light storyLight;
    [SerializeField] private Light keyLight;

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

    public void EnableBoxLight()
    {  
        boxLight.enabled = true;
        
    }

    public void DisableBoxLight()
    {
        boxLight.enabled = false;
    }

    internal void EnableStoryLight()
    {
        storyLight.enabled = true;
    }

    internal void DisableStoryLight()
    {
        storyLight.enabled = false;
    }

    internal void EnableKeyLight()
    {
        keyLight.enabled = true;
    }
}