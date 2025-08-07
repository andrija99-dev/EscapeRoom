using System;
using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject boxUI;
    [SerializeField] private GameObject InteractionUI;

    [Header("CustomizableMessage")]
    [SerializeField] private GameObject showMessageUI;
    [SerializeField] private TextMeshProUGUI messageText;

    [Header("CustomizablePopUp")]
    [SerializeField] private GameObject popUpUI;
    [SerializeField] private TextMeshProUGUI popUpText;
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

    public void ShowMessageUI(string message)
    {
        if (!showMessageUI.activeSelf)
        {
            showMessageUI.SetActive(true);
        }
        messageText.text = message;
    }

    public void HideMessageUI()
    {
        if (showMessageUI.activeSelf)
        {
            messageText.text = "";
            showMessageUI.SetActive(false);
        }
    }

    public void ShowPopUpUI(string message, float timeframe)
    {
        StartCoroutine(ShowPopUpCoroutine(message, timeframe));
    }

    private IEnumerator ShowPopUpCoroutine(string message, float timeframe)
    {
        popUpUI.SetActive(true);
        popUpText.text = message;

        yield return new WaitForSeconds(timeframe);

        popUpText.text = "";
        popUpUI.SetActive(false);
    }
}