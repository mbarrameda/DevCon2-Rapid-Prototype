using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    // Move the clone with the arrow keys
    void Move()
    {
        float moveInput = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1;
        if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // Jump with the up arrow
    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Method to detect coin collection
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) // Check if the collided object is a coin
        {
            PlayerController playerController = FindObjectOfType<PlayerController>(); // Find the PlayerController instance
            if (playerController != null)
            {
                playerController.IncreaseScore(1); // Increase the score in PlayerController
            }

            // Destroy the coin GameObject
            Destroy(other.gameObject);
        }
    }
}
