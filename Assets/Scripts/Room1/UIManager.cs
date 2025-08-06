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
        InteractionUI.SetActive(true);
    }

    public void HideInteractionUI()
    {
        InteractionUI.SetActive(false);
    }

    public void ShowBoxUI()
    {
        boxUI.SetActive(true);
    }

    public void HideBoxUI()
    {
        boxUI.SetActive(false);
    }
}