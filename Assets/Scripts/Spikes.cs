using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collides with the spikes is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the spikes."); // Log player collision
            ResetScene(); // Call the method to reset the scene
        }

        // Check if the object that collides with the spikes is tagged as "Clone"
        if (other.CompareTag("Clone"))
        {
            Destroy(other.gameObject); // Destroy the clone
            Debug.Log("Clone destroyed");
        }
    }

    private void ResetScene()
    {
        // Get the current scene and reload it
        Scene currentScene = SceneManager.GetActiveScene(); // Get the currently active scene
        SceneManager.LoadScene(currentScene.name); // Reload the current scene
    }
}
