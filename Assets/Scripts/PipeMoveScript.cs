using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    //Pipe Movement Fields
    public float moveSpeed = 5;
    public float deadZoneX = -26;

    // Update is called once per frame
    void Update()
    {
        //Update Pipe using delta time and moveSpeed variable to ensure smooth
        //and consistent movement across machines with varying computer specs
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        //Check if pipe has passed the left bound of screen (check if off-screen)
        //and destroy pipe if so to free up memory
        if (transform.position.x < deadZoneX)
        {
            Destroy(gameObject);
        }
    }
}

