using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    float dirX, moveSpeed = 5f;
    bool isGrounded; // Flag to track if the player is grounded
    Animator animator; // Reference to the Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        // Flip the player sprite if moving left
        if (dirX != 0)
        {
            spriteRenderer.flipX = dirX > 0;
        }

        // Check if the player presses the Jump button and is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * 400f);
            isGrounded = false; // Set the grounded flag to false
        }

        // Update the animation parameters based on the player's movement and jumping state
        UpdateAnimationParameters();
    }

    void FixedUpdate()
    {
        // If the player is not pressing any movement keys, set the velocity to zero
        if (dirX == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true; // Player is grounded when colliding with the ground or platform
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = false; // Player is no longer grounded when leaving the ground or platform
        }
    }

    void UpdateAnimationParameters()
    {
        // Set the "Speed" parameter in the animator based on the player's horizontal velocity
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        
        // Set the "IsGrounded" parameter in the animator based on whether the player is grounded or not
        animator.SetBool("IsGrounded", isGrounded);
    }


}

