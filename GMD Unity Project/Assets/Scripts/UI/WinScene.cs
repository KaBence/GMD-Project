using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    [SerializeField] private GameObject winPopupPanel;
    // [SerializeField] private GameObject IngameUI;

    void Start()
    {
        winPopupPanel.SetActive(false);
    }

    public void ShowWinPopup()
    {
        // IngameUI.SetActive(false);
        winPopupPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void NextScene()
    {
        Debug.Log("Next scene...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
