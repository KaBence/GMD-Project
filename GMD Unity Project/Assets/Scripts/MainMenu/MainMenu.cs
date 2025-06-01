using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayFirst(){
        SceneManager.LoadScene("Game1-1");
    }
    
    public void PlaySecond()
    {
        SceneManager.LoadScene("Game1-2");
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
