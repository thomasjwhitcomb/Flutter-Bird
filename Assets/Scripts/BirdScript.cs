using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    // References to Components
    public Rigidbody2D myRigidbody;
    public InputActionReference jump;

    // Bird Properties
    public float flapStrength = 10f;
    public bool isAlive = true;

    public LogicScript logicScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get LogicScript Component to use Game Over method
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if bird is within screen upper and lower bounds
        if(transform.position.y > 13 || transform.position.y < -13)
        {
            logicScript.gameOver(); //Game Over if Bird is off screen
            isAlive = false; //Update isAlive status to block user input after game end
        }
    }

    //Method to begin Jumps using Unity Input System
    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    //Method to end Jumps using Unity Input System
    private void OnDisable()
    {
        jump.action.started -= Jump;

    }

    //Method checks if the bird is alive, then updates velocity to simulate jumping
    //with set flapStrength constant.
    private void Jump(InputAction.CallbackContext context)
    {
        if(isAlive) //Check if bird isAlive
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength; //Jump
        }
    }

    //Method checks for a collision with any pipes, and ends game if so
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver(); //Game Over Method
        isAlive = false; //Change isAlive status to reflect Game Over
    }

}
