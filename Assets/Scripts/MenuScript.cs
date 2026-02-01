using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //Method to Load Game from Start/Menu Screen
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    //Method to Quit Game from Start/Menu Screen
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

