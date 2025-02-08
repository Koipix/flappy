using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float jumpIntesity = 10;
    public int score;

    public Text scoreText;
    private Camera mainCamera; // Store the main camera

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.gravityScale = 2;
        mainCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerBody.linearVelocity = Vector2.up * jumpIntesity;
        }

        // Keep player within viewport bounds
        KeepPlayerInViewport();
    }

    void KeepPlayerInViewport()
    {
        if (mainCamera == null) return; // Important check!

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check and correct horizontal position
        if (viewportPos.x < 0)
        {
            viewportPos.x = 0;
        }
        else if (viewportPos.x > 1)
        {
            viewportPos.x = 1;
        }

        // Check and correct vertical position (optional - depends on your game)
        if (viewportPos.y < 0)
        {
            viewportPos.y = 0;
        }
        else if (viewportPos.y > 1)
        {
            viewportPos.y = 1;
        }

        // Convert back to world coordinates and set the player's position
        transform.position = mainCamera.ViewportToWorldPoint(viewportPos);
        // Important: Reset the Rigidbody's velocity after repositioning, to prevent accumulation of force
        //playerBody.linearVelocity = Vector2.zero; // or playerBody.velocity = new Vector2(0, playerBody.velocity.y); to keep vertical velocity
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("Score Text UI element not assigned!");
        }
    }
}
