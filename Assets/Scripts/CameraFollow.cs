using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      // Reference to the player's transform
    public Vector3 offset;        // Offset of the camera relative to the player
    public float smoothSpeed = 0.125f;  // Speed of the camera's smooth follow

    void FixedUpdate()
    {
        // Target position based on player's position and the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera to the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position
        transform.position = smoothedPosition;
    }
}
