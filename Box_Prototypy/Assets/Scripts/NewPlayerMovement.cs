using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;
    bool isGrounded; // Flag to track if the player is grounded
    Transform platform; // Reference to the moving platform the player is on

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * 400f);
            isGrounded = false; // Player is no longer grounded after jumping
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("MovingPlatform"))
        {
            platform = col.transform;
            transform.SetParent(platform); // Parent the player to the platform
            isGrounded = true; // Player is grounded when colliding with the ground or platform
        }
    }

void OnCollisionExit2D(Collision2D col)
{
    if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("MovingPlatform"))
    {
        // Check if the parent GameObject is active before attempting to change the parent
        if (col.transform.gameObject.activeSelf && transform.parent == col.transform)
        {
            transform.SetParent(null); // Unparent the player from the platform
            platform = null;
            isGrounded = false; // Player is no longer grounded when leaving the ground or platform
        }
    }
}



}

