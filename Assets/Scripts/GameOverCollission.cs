using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI elements

public class GameOverOnCollision : MonoBehaviour
{
    public Text gameOverText; // Assign your Game Over Text object in the Inspector

    private void Start()
    {
        // Initially hide the Game Over text
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); // or gameOverText.enabled = false;
        }
        else
        {
            Debug.LogError("Game Over Text not assigned in GameOverOnCollision script!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandleGameOver(other.gameObject); // Call the common game over function
        }
    }

    //For more precise collision detection, use OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandleGameOver(collision.gameObject); // Call the common game over function
        }
    }

    private void HandleGameOver(GameObject player) // Takes the player GameObject as a parameter
    {
        Debug.Log("Game Over!");

        // 1. Show the Game Over Text
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true); // or gameOverText.enabled = true;
        }

        // 2. Disable Player Control
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        if (playerScript != null)
        {
            playerScript.enabled = false;
        }

        // 3. (Optional) Pause the game
        // Time.timeScale = 0; // Freezes the game

        // 4. (Optional) Add a restart button or other game over logic
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
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Or if you want to load a specific scene:
        // SceneManager.LoadScene("Level1"); // Replace with your scene name.

        // If you had Time.timeScale = 0; in HandleGameOver(), reset it here:
        Time.timeScale = 1;

        // If you had any other reset logic (e.g., re-enabling other scripts), put it here.
    }
}