using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private GameObject exitGameButton;
    [SerializeField] private FPSController playerController;
    private MacroHandler hButtonScript;
    [SerializeField] private AudioClip victoryMusic;

    private void Awake()
    {
        hButtonScript = GetComponent<MacroHandler>();
    }

    public void ShowVictoryScreen()
    {
        playerController.enabled = false;
        hButtonScript.enabled = false;
        exitGameButton.SetActive(false);
        hintPanel.SetActive(false);

        victoryPanel.SetActive(true);
        SoundManager.Instance.PlayMusic(victoryMusic);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnExitClicked()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}