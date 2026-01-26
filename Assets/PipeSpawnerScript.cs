using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    //GameObject Reference
    public GameObject pipePrefab;

    //Pipe Spawner Variables
    public float spawnRate = 2.5f;
    public float verticalOffset = 10f;
    private float spawnTimer = 0f;
    
    // Update is called once per frame
    void Update()
    {
        //Check if spawnTimer has elapsed
        if (spawnTimer < spawnRate) //If not, continue timer
        {
            spawnTimer += Time.deltaTime;
        }
        else //If timer is up
        {
            SpawnPipe(); //Spawn Pipe
            spawnTimer = 0f; //Reset pipe spawnTimer
        }
    }

    //Method to randomly generate pipe between vertical offset bounds
    private void SpawnPipe()
    {
        //Vertial Offset Lower and Upper Bounds
        float lowestPoint = transform.position.y - verticalOffset;
        float highestPoint = transform.position.y + verticalOffset;

        //Create new pipe GameObject between given lower and upper bounds
        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),transform.position.z), transform.rotation);
    }
}

