using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance;

    [SerializeField] private Light boxLight;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void EnableBoxLight()
    {  
        boxLight.enabled = true;
        
    }

    public void DisableBoxLight()
    {
        boxLight.enabled = false;
    }
}