using UnityEngine;

public class Check : MonoBehaviour
{
    public int scoreToAdd = 1; // Make this public to adjust in the Inspector
    private bool collected = false; // Track if the object has been collected
    private PlayerScript player; // Store the PlayerScript reference

    void Start()
    {
        // Find the Player GameObject and get the PlayerScript component
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        if (player == null)
        {
            Debug.LogError("Player GameObject with tag 'Player' not found, or PlayerScript is missing!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected && player != null) // Check player is found
        {
            Collect();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collected && player != null) // Check player is found
        {
            Collect();
        }
    }
    private void Collect()
    {
        collected = true;
        player.score += scoreToAdd;
        player.UpdateScoreUI();
        //Destroy(gameObject); // Or gameObject.SetActive(false);
        Debug.Log("Check object collected!");
    }
}