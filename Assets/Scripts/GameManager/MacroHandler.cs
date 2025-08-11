using UnityEngine;

public class MacroHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowHint();
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    private void ShowHint()
    {
        if (HintManager.Instance == null || UIManager.Instance == null)
            return;

        string hint = HintManager.Instance.GetCurrentHint();
        if (!string.IsNullOrEmpty(hint))
        {
            UIManager.Instance.ShowPopUpUI(hint, 6f);
        }
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}