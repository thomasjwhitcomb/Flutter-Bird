using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    //UI Fields
    public int playerScore = 0;
    public Text scoreText;
    public Text highScoreText;
    public Text gameOverTaunt;
    bool tauntSet = false;
    
    //GameObject References
    public GameObject gameOverScreen;
    public BirdScript BirdScript;
    
    //Audio Components
    public AudioSource dingSFX;
    
    void Start()
    {
        //Obtain BirdScript to access isAlive status
        BirdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        //Update High Score on game launch
        UpdateHighScore();
    }

    //Method to increase score when pole is successfully passed through
    public void addScore()
    {
        if (BirdScript.isAlive) //Check isAlive status before altering score
        {
        playerScore += 1; //Add one to current score
        scoreText.text = "Score: " + playerScore.ToString(); //Update on screen text
        dingSFX.Play(); //Play audio cue when scored
        }
        checkHighScore(); //Check if new High Score has been set
    }
    
    //Method to Update on-screen High Score Text
    public void UpdateHighScore()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    //Method to check if new High Score has been set
    public void checkHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); //Get stored High Score
        if (playerScore > highScore) //Check if High Score has been broken
        {
            PlayerPrefs.SetInt("HighScore", playerScore); //Set new High Score
            highScoreText.text = "New High Score: " + playerScore.ToString(); //Update New High Score
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString(); //Keep OG High Score
        }
    }

    //Method to restart game after a game over
    public void restartGame()
    {
        gameOverTaunt.text = ""; //Clear game over taunt
        tauntSet = false; //Reset tauntSet status
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Load Game Scene
        BirdScript.isAlive = true; //Resrt isAlive status
    }

    //Method for Game Over Screen
    public void gameOver()
    {
        gameOverScreen.SetActive(true); //Change status to show Game Over Screen
        if(!tauntSet){ //Check if a taunt has been set
            setTauntText(); //Set taunt text
            tauntSet = true; //Update tauntSet status
        }
    }
    //Method to Return to Menu from Game Over Screen
    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //Method to set a randomized taunt
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

        //Set Game Over Taunt text from array of taunts
        gameOverTaunt.text = taunts[UnityEngine.Random.Range(0, taunts.Length)];
    }
}

