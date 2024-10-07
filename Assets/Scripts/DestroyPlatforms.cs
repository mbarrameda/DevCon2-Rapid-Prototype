using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float destroyDelay = 1f; // Delay before destroying the platform

    // Method to activate the destruction of the platform when triggered by a button
    public void ActivatePlatform()
    {
        StartCoroutine(DestroyPlatformAfterDelay());
    }

    private IEnumerator DestroyPlatformAfterDelay()
    {
        // Optionally, you can add a visual effect or sound here before destroying
        yield return new WaitForSeconds(destroyDelay); // Wait for the specified delay
        Destroy(gameObject); // Destroy the platform GameObject
    }
}
