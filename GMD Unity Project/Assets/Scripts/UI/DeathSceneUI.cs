using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneUI : MonoBehaviour
{
    [SerializeField] private GameObject deathPopupPanel;

    void Start()
    {
        deathPopupPanel.SetActive(false);
    }

    public void ShowDeathPopup()
    {
        deathPopupPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void RestartScene()
    {
        Debug.Log("Restarting scene...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
