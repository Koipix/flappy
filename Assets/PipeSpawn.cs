using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 2;

    void Start()
    {
        pipe = Resources.Load<GameObject>("Pipe");
        SpawnPipe();

    }

    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), -2), transform.rotation);
    }
}
