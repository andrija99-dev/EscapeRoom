using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class PadlockController : MonoBehaviour
{
    [SerializeField] private PadlockRing[] rings; 
    [SerializeField] private int[] correctCode = new int[4];
    [SerializeField] private GameObject boxSystem;
    [SerializeField] private GameObject key;
    [SerializeField] private AudioClip openingBoxSound;
    [SerializeField] private AudioClip wrongCodeSound;

    private int selectedRing = 0;


    

    void Update()
    {        

        if (!InteractionManager.IsInteractingWithUI || Interactable.currentInteractable != boxSystem.GetComponent<Interactable>())
        {
            return;
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
            UIManager.Instance.HideBoxUI(InteractionManager.CurrentRoom);
            UIManager.Instance.ShowPopUpUI("Congratulations!\r\nTake the key!", 2.5f);
            SoundManager.Instance.PlaySFX(openingBoxSound);
            LightManager.Instance.EnableDoorLight(InteractionManager.CurrentRoom);

        }
        else
        {
            UIManager.Instance.ShowPopUpUI("Wrong code", 1f);
            SoundManager.Instance.PlaySFX(wrongCodeSound);

        }
    }
    
    public void ResetSelectedRing()
    {
        selectedRing = 0;
    }

}