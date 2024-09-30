using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private PlayerController playerController;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            // Mimic the player's movement input
            float moveInput = playerController.GetMoveInput();
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            // Mimic jumping based on player input
            if (playerController.IsGrounded() && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    public void SetPlayerReference(GameObject playerReference)
    {
        player = playerReference;
        playerController = player.GetComponent<PlayerController>();
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
}
