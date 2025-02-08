using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI elements

public class GameOverOnCollision : MonoBehaviour
{
    public Text gameOverText; // Assign your Game Over Text object in the Inspector

    private PlayerScript playerScript; // Store the PlayerScript reference

    private void Start()
    {
        // Initially hide the Game Over text
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Game Over Text not assigned in GameOverOnCollision script!");
        }

        // Find the PlayerScript in the scene (using GetComponent on the Player)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<PlayerScript>();
        }
        else
        {
            Debug.LogError("Player GameObject with tag 'Player' not found in the scene!");
        }

        if (playerScript == null)
        {
            Debug.LogError("PlayerScript component not found on the Player GameObject!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandleGameOver(); // No need to pass the GameObject anymore
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandleGameOver(); // No need to pass the GameObject anymore
        }
    }

    private void HandleGameOver() // No parameter needed
    {
        Debug.Log("Game Over!");

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        if (playerScript != null) // Check if playerScript was found
        {
            playerScript.enabled = false;
        }

        // Time.timeScale = 0; // Optional: Pause the game
    }

    private void Update() // Check for 'R' key press even if game over hasn't happened yet.
    {
        if (Input.GetKeyDown(KeyCode.R)) // Only if game over text is showing.
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

        // Re-enable PlayerScript (if you paused the game)
        if (playerScript != null)
        {
            playerScript.enabled = true;
        }
    }
}
