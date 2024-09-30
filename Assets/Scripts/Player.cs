using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public GameObject clonePrefab; // Assign the clone prefab in Unity Inspector
    public float cloneSpawnOffset = 2f; // Distance from the player where clones will spawn

    private bool isGrounded = false;
    private Rigidbody2D rb;
    private List<GameObject> clones = new List<GameObject>();
    private int maxClones = 2;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();

        if (Input.GetKeyDown(KeyCode.E))  // Press "E" to create clones
        {
            if (clones.Count < maxClones)
            {
                CreateClone();
            }
        }
    }

    void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void CreateClone()
    {
        // Determine the direction to spawn the clone
        Vector3 spawnPosition = transform.position;

        if (moveInput > 0) // Player is moving to the right
        {
            spawnPosition += new Vector3(cloneSpawnOffset, 0, 0);
        }
        else if (moveInput < 0) // Player is moving to the left
        {
            spawnPosition -= new Vector3(cloneSpawnOffset, 0, 0);
        }
        else // If player is not moving, spawn directly above
        {
            spawnPosition += new Vector3(0, cloneSpawnOffset, 0);
        }

        // Create clone and set it to mimic the player's behavior
        GameObject clone = Instantiate(clonePrefab, spawnPosition, Quaternion.identity);
        CloneController cloneController = clone.GetComponent<CloneController>();
        cloneController.SetPlayerReference(this.gameObject); // Pass player reference to the clone
        clones.Add(clone);
        StartCoroutine(DestroyCloneAfterTime(clone, 20f));  // Destroy clone after 20 seconds
    }

    IEnumerator DestroyCloneAfterTime(GameObject clone, float delay)
    {
        yield return new WaitForSeconds(delay);
        clones.Remove(clone);
        Destroy(clone);
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

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public float GetMoveInput()
    {
        return moveInput;
    }
}
