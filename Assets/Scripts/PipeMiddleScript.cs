using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logicScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get LogicScript to access addScore method
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    //Method to update score when bird successfully passes through pipe
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if Bird has passed through pipe
        if (collision.gameObject.layer == 3) // 3 = Bird Layer
        {
            logicScript.addScore(); //Update Score
        }
    }
}

