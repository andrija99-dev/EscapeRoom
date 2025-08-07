using System;
using TMPro;
using UnityEngine;

public class PadlockController : MonoBehaviour
{
    [SerializeField] private PadlockRing[] rings; 
    [SerializeField] private int[] correctCode = new int[4];
    [SerializeField] private TextMeshProUGUI controlsText;
    [SerializeField] private GameObject boxSystem;
    [SerializeField] private GameObject key;
    private PadlockInteractable padlockInteractable;
    private int selectedRing = 0;


    private void Awake()
    {
        controlsText.text = "A / D - Menja prsten\r\nW / S - Rotira broj\r\nE - Izlaz";
        padlockInteractable = boxSystem.GetComponent<PadlockInteractable>();
    }    

    void Update()
    {        

        if (!InteractionManager.IsInteractingWithUI)
        {
            return;
        }
        if (InteractionManager.IsInteractingWithUI && Input.GetKeyDown(KeyCode.Escape))
        {
            
            padlockInteractable.ExitUI();
        }

        if (Input.GetKeyDown(KeyCode.A))
            selectedRing = Mathf.Max(0, selectedRing - 1);
        if (Input.GetKeyDown(KeyCode.D))
            selectedRing = Mathf.Min(rings.Length - 1, selectedRing + 1);

        if (Input.GetKeyDown(KeyCode.W))
            rings[selectedRing].Rotate(1);

        if (Input.GetKeyDown(KeyCode.S))
            rings[selectedRing].Rotate(-1);
    }

    public bool IsCorrectCombination()
    {
        for (int i = 0; i < correctCode.Length; i++)
        {
            if (rings[i].RingValue != correctCode[i])
                return false;
        }
        return true;
    }

    public void ValidateCode()
    {
        if (IsCorrectCombination())
        {
            boxSystem.layer = LayerMask.NameToLayer("Default");
            key.SetActive(true);
            key.GetComponent<KeyMover>().StartMoving();
            UIManager.Instance.HideBoxUI();

        }
        else
        {
            Debug.Log("Pogresan kod.");
        }
    }
    
    public void ResetSelectedRing()
    {
        selectedRing = 0;
    }

}