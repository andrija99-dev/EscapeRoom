using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject boxUI;
    [SerializeField] private GameObject InteractionUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowInteractionUI()
    {
        if (!InteractionUI.activeSelf)
        {
            InteractionUI.SetActive(true);
        }
    }

    public void HideInteractionUI()
    {
        if (InteractionUI.activeSelf)
        {
            InteractionUI.SetActive(false);
        }
    }

    public void ShowBoxUI()
    {
        if (!boxUI.activeSelf)
        {
            boxUI.SetActive(true);
        }
    }

    public void HideBoxUI()
    {
        if (boxUI.activeSelf)
        {
            boxUI.SetActive(false);
        }
    }
}