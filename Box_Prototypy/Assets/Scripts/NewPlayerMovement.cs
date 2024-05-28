using System.Collections;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    float dirX, moveSpeed = 5f;
    bool isGrounded; // Flag to track if the player is grounded
    Animator animator; // Reference to the Animator component
    AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip jumpSound; // Reference to the jump sound clip

    public SpriteRenderer sprite;

  //for Damage Flash Red
    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
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
            PlayJumpSound(); // Play the jump sound
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
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("MovingPlatform") || col.gameObject.CompareTag("Nervenende"))
        {
            isGrounded = true; // Player is grounded when colliding with the ground or platform
        }

        if (col.gameObject.CompareTag("Nervenende") || col.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(FlashRed());
        }

        
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("MovingPlatform") || col.gameObject.CompareTag("Nervenende"))
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

    void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound); // Play the jump sound
    }
}
