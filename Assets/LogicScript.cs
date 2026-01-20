using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public BirdScript BirdScript;
    public AudioSource dingSFX;
    public Text gameOverTaunt;
    bool tauntSet = false;
    public Text highScoreText;

    void Start()
    {
        BirdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        UpdateHighScore();
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        if (BirdScript.isAlive)
        {
        playerScore += 1;
        scoreText.text = "Score: " + playerScore.ToString();
        dingSFX.Play();
        }
        checkHighScore();
    }
    public void UpdateHighScore()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void checkHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = "New High Score: " + playerScore.ToString();
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }


    public void restartGame()
    {
        gameOverTaunt.text = "";
        tauntSet = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        BirdScript.isAlive = true;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if(!tauntSet){
            setTauntText();
            tauntSet = true;
        }
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setTauntText()
    {
        String[] taunts = {
            "Is that all you've got?",
            "My grandma flies better than you!",
            "Maybe stick to walking?",
            "You know there was a pole there right?",
            "You call that flying?",
            "I've seen soggy napkins fly better!",
            "Did you forget how to be a bird?"
        };

        gameOverTaunt.text = taunts[UnityEngine.Random.Range(0, taunts.Length)];
    }
}
