using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;            // Start point of the platform
    public Transform pointB;            // End point of the platform
    public float speed = 2f;            // Speed of the platform
    private bool isActivated = false;   // To check if the platform has been activated
    private bool isMoving = false;      // To check if the platform is moving

    void Start()
    {
        // Start the platform at pointA
        transform.position = pointA.position;
    }

    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    // Method called by ButtonTrigger to activate the platform movement
    public void ActivatePlatform()
    {
        if (!isActivated)
        {
            isActivated = true;
            isMoving = true; // Start moving the platform once activated
        }
    }

    void MovePlatform()
    {
        // Move the platform towards pointB
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

        // Check if the platform has reached pointB
        if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
        {
            isMoving = false;  // Stop moving when the platform reaches pointB
        }
    }
}
