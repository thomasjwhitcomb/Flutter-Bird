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
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 13 || transform.position.y < -13)
        {
            logicScript.gameOver();
            isAlive = false;
        }
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;

    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(isAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
        isAlive = false;
    }
}