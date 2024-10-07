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

    // Move the player using "A" and "D" keys
    void Move()
    {
        float moveInput = 0;
        if (Input.GetKey(KeyCode.A)) moveInput = -1;
        if (Input.GetKey(KeyCode.D)) moveInput = 1;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // Jump with the spacebar
    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void CreateClone()
    {
        // Determine the direction to spawn the clone
        Vector3 spawnPosition = transform.position + new Vector3(cloneSpawnOffset, 0, 0);
        GameObject clone = Instantiate(clonePrefab, spawnPosition, Quaternion.identity);
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
}
