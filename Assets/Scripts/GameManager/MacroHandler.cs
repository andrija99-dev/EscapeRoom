using UnityEngine;

public class MacroHandler : MonoBehaviour
{
    [SerializeField] private GameObject popUpUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowHint();
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ShowExitGamePanel();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void ShowHint()
    {
        if (HintManager.Instance == null || UIManager.Instance == null)
            return;

        if (popUpUI.activeSelf)
        {
            return;
        }

        string hint = HintManager.Instance.GetCurrentHint();
        if (!string.IsNullOrEmpty(hint))
        {
            UIManager.Instance.ShowPopUpUI(hint, 6f);
        }
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void DontExitGame()
    {
        UIManager.Instance.HideExitGamePanel();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}