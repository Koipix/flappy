using UnityEngine;

public class Check : MonoBehaviour
{
    public int scoreToAdd = 1; // Make this public to adjust in the Inspector
    private bool collected = false; // Track if the object has been collected

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected) // Check tag and if not already collected
        {
            collected = true; // Prevent multiple collections

            // Get the PlayerScript and add the score
            PlayerScript player = other.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.score += scoreToAdd;
                player.UpdateScoreUI(); // Update the score UI

                // Destroy the "Check" object (optional)
                //Destroy(gameObject);

                // Or, disable the "Check" object instead of destroying it
                // gameObject.SetActive(false); 

                // You can also play a sound effect or other visual feedback here.
                Debug.Log("Check object collected!");
            }
            else
            {
                Debug.LogError("PlayerScript not found on the player object!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collected)
        {
            collected = true;

            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.score += scoreToAdd;
                player.UpdateScoreUI();
                //Destroy(gameObject);
                Debug.Log("Check object collected!");
            }
            else
            {
                Debug.LogError("PlayerScript not found on the player object!");
            }
        }
    }
}