using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject InteractionUI;

    [Header("Box Number 1")]
    [SerializeField] private GameObject boxNumber1UI;

    [Header("Box Number 2")]
    [SerializeField] private GameObject boxNumber2UI;

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

    public void ShowBoxUI(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:

                if (!boxNumber1UI.activeSelf)
                {
                    boxNumber1UI.SetActive(true);
                }
                break;
            case 2:

                if (!boxNumber2UI.activeSelf)
                {
                    boxNumber2UI.SetActive(true);
                }
                break;

            default:
                break;
        }

    }

    public void HideBoxUI(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:

                if (boxNumber1UI.activeSelf)
                {
                    boxNumber1UI.SetActive(false);
                }
                break;
            case 2:

                if (boxNumber2UI.activeSelf)
                {
                    boxNumber2UI.SetActive(false);
                }
                break;

            default:
                if (boxNumber2UI.activeSelf)
                {
                    boxNumber2UI.SetActive(false);
                }
                else if (boxNumber1UI.activeSelf)
                {
                    boxNumber1UI.SetActive(false);
                }
                break;
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
        if (!popUpUI.activeSelf)
        {
            StartCoroutine(ShowPopUpCoroutine(message, timeframe));
        }
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