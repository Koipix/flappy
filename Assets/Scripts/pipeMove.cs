using UnityEngine;

public class pipeMove : MonoBehaviour
{
    public float moveSpeed;
    public DifficultySO difficulty;

    void Start()
    {
        PipeSpawn spawn = FindFirstObjectByType<PipeSpawn>(); // Find the PipeSpawn in the scene
        if (spawn != null)
        {
            difficulty = spawn.difficulty;
        }
    }

    void Update()
    {
        if (difficulty != null)
        {
            transform.position += Vector3.left * difficulty.moveSpeed * Time.deltaTime;
        }
    }
}
