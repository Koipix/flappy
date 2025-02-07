using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float jumpIntesity = 10;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.gravityScale = 2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerBody.linearVelocity = Vector2.up * jumpIntesity;
        }
    }
}
