using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class FinishLine : MonoBehaviour
{
    // Method to detect collisions with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collided object is the player
        {
            ResetGame(); // Call the ResetGame method
        }
    }

    private void ResetGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
