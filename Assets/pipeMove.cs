using UnityEngine;

public class pipeMove : MonoBehaviour
{
    public float moveSpeed = 3;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
