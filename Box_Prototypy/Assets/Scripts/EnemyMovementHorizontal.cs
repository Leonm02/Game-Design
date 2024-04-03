using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalMovement : MonoBehaviour
{
    public float moveDistance = 2f; // Distance to move left and right
    public float moveSpeed = 2f; // Speed of movement

    private Vector3 startPos; // Starting position
    private bool moveRight = true; // Flag to determine direction of movement

    void Start()
    {
        startPos = transform.position; // Store the starting position
    }

    void Update()
    {
        // Calculate the horizontal movement
        float horizontalMovement = moveRight ? moveSpeed * Time.deltaTime : -moveSpeed * Time.deltaTime;

        // Calculate the new position
        Vector3 newPos = transform.position + new Vector3(horizontalMovement, 0f, 0f);

        // Move the object to the new position
        transform.position = newPos;

        // Check if the enemy needs to change direction
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            moveRight = !moveRight; // Change direction
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the player GameObject
            Destroy(other.gameObject);
            // You can add your game over logic here, like showing a game over screen, resetting the level, etc.
            Debug.Log("Player destroyed - Game Over!");
        }
    }
}