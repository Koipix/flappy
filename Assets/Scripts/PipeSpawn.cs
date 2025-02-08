using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public DifficultySO difficulty; // Assign your DifficultySO in the Inspector
    private float timer = 0;
   
    void Start()
    {
        pipe = Resources.Load<GameObject>("Pipe");
        SpawnPipe();

    }

    void Update()
    {
        //if (timer < difficulty.spawnRate) {
        //    timer += Time.deltaTime;
        //} 
        //else 
        //{
        //    SpawnPipe();
        //    timer = 0;
        //}

        if (timer > 1f / difficulty.spawnRate) // Changed condition
        {
            SpawnPipe();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void SpawnPipe() {
        float lowestPoint = transform.position.y - difficulty.heightOffset;
        float highestPoint = transform.position.y + difficulty.heightOffset;

        GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), -2), transform.rotation);

        // Add a PipeDestroyer script to the newly spawned pipe
        PipeDestroy destroyer = newPipe.AddComponent<PipeDestroy>();
        destroyer.SetCamera(Camera.main); // Pass the main camera to the destroyer

        pipeMove moveScript = newPipe.GetComponent<pipeMove>(); // Get the pipeMove component
        if (moveScript != null)
        {
            moveScript.difficulty = difficulty; // Assign the DifficultySO to the pipe
        }
    }
}

