using TMPro;
using UnityEngine;

public class PadlockController : MonoBehaviour
{
    [SerializeField] private Transform[] rings; 
    [SerializeField] private int[] correctCode = new int[4];
    [SerializeField] private TextMeshProUGUI controlsText;
    private int[] currentValues = new int[4]; 
    private float anglePerStep = 36f;
    private float offset = 216f; 
    public int selectedRing = 0;

    private void Awake()
    {
        controlsText.text = "A / D - Menja prsten\r\nW / S - Rotira broj\r\nE - Izlaz";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            selectedRing = Mathf.Max(0, selectedRing - 1);
        if (Input.GetKeyDown(KeyCode.D))
            selectedRing = Mathf.Min(rings.Length - 1, selectedRing + 1);

        if (Input.GetKeyDown(KeyCode.W))
            RotateRing(selectedRing, 1); 
        if (Input.GetKeyDown(KeyCode.S))
            RotateRing(selectedRing, -1); 
    }

    void RotateRing(int index, int direction)
    {
        currentValues[index] = (currentValues[index] + direction + 10) % 10;
        float angle = offset - currentValues[index] * anglePerStep;
        rings[index].localRotation = Quaternion.Euler(angle, 0f, 0f);
    }

    public bool IsCorrectCombination()
    {
        for (int i = 0; i < correctCode.Length; i++)
        {
            if (currentValues[i] != correctCode[i])
                return false;
        }
        return true;
    }

    public void ValidateCode()
    {
        if (IsCorrectCombination())
        {
            Debug.Log("Otkljucano!");
            // TODO: Get Key...
        }
        else
        {
            Debug.Log("Pogresan kod.");
        }
    }
}