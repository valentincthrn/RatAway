using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5.0f; // adjustable in the inspector
    public Transform groundCheck; // reference to an empty GameObject used for checking if grounded
    public float groundCheckRadius = 0.2f; // radius for ground check
    public LayerMask groundLayer; // layer to represent the ground

    private int jumpCount = 0;
    private const int maxJumpCount = 1; // max number of jumps before touching the ground
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Check if the space bar is pressed and the player hasn't jumped the maximum number of jumps
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Reset vertical velocity (for consistent double jumps)
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        // Add vertical force to the Rigidbody for the jump
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        jumpCount++;
    }
}
