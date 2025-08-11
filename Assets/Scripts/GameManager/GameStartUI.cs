using UnityEngine;
using UnityEngine.UI;

public class GameStartUI : MonoBehaviour
{
    [SerializeField] private GameObject panel; 
    [SerializeField] private GameObject hintPanel; 
    [SerializeField] private GameObject exitGameButton; 
    [SerializeField] private FPSController playerController; 
    private MacroHandler hButtonScript;


    private void Awake()
    {
        hButtonScript = GetComponent<MacroHandler>();
    }

    private void Start()
    {
        
        playerController.enabled = false;
        hButtonScript.enabled = false;
        exitGameButton.SetActive(false);
        hintPanel.SetActive(false);
        panel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnLetsGoClicked()
    {
        playerController.enabled = true;
        hButtonScript.enabled = true;

        panel.SetActive(false);
        exitGameButton.SetActive(true);
        hintPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}