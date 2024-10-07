using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.IncreaseScore(1); // Increase score by 1 when coin is collected
            }

            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        // Optionally, add visual/audio feedback for collecting the coin
        Debug.Log("Coin collected!");

        // Destroy the coin GameObject
        Destroy(gameObject);
    }
}
