using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    // private SceneController _sceneController;
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
