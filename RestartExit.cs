using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartExit : MonoBehaviour
{
    public void ChangeSceneTo(string SceneToLoad)
    {
        
        SceneManager.LoadScene(SceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
