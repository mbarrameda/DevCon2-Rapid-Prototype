using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public MovingPlatform[] movingPlatforms;  // Array of platforms this button can activate
    private bool[] isActivated;               // Track if each platform has been activated

    void Start()
    {
        // Initialize the isActivated array with the size of the platforms array
        isActivated = new bool[movingPlatforms.Length];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the clone
        if (other.CompareTag("Clone"))
        {
            // Loop through each platform and activate the ones that are not activated
            for (int i = 0; i < movingPlatforms.Length; i++)
            {
                if (!isActivated[i])
                {
                    isActivated[i] = true;
                    movingPlatforms[i].ActivatePlatform();  // Activate the platform movement
                }
            }
        }
    }
}
