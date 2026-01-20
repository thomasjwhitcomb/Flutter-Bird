using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
