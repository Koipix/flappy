using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float jumpIntesity = 10;
    public int score;
    public int currentPlayerIndex = 0; // Keep track of the selected index

    public Text scoreText;
    private Camera mainCamera; // Store the main camera
    private Rigidbody2D[] playerBodies; // Array to hold Rigidbody2D components
    private GameObject[] playerInstances; // Array to hold instantiated player GameObjects
    public GameObject[] playerPrefabs; // Array of player prefabs

    void Awake()  // Use Awake so it happens before CharacterSelect's Start
    {
        mainCamera = Camera.main;

        // Find the Score Text object by name
        scoreText = GameObject.Find("Score").GetComponent<Text>();

        if (playerPrefabs == null || playerPrefabs.Length == 0)
        {
            Debug.LogError("Player Prefabs not assigned or empty in PlayerScript!");
            return;
        }

        // playerBody = GetComponent<Rigidbody2D>(); // Remove this. We will get it from the instantiated prefab
    }

    public void InstantiatePlayer(int index) // New function to instantiate the player
    {
        // Destroy existing player instance if any
        if (playerBody != null)
        {
            Destroy(playerBody.gameObject); // Destroy the GameObject the Rigidbody is attached to
        }

        GameObject playerInstance = Instantiate(playerPrefabs[index], transform.position, transform.rotation);
        playerBody = playerInstance.GetComponent<Rigidbody2D>();

        if (playerBody == null)
        {
            Debug.LogError("Rigidbody2D not found on player prefab at index " + index + "!");
            return;
        }

        playerBody.gravityScale = 2;
    }

    void Start()
    {
        // playerBody.gravityScale = 2; // Moved to InstantiatePlayer
        UpdateScoreUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerBody.linearVelocity = Vector2.up * jumpIntesity;
        }

        // Keep player within viewport bounds
        KeepPlayerInViewport();
    }

    void KeepPlayerInViewport()
    {
        if (mainCamera == null) return; // Important check!

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(playerBody.transform.position); // Use current player

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
        playerBody.transform.position = mainCamera.ViewportToWorldPoint(viewportPos);
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
