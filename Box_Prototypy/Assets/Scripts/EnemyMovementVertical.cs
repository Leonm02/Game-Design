using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantUpDownMovement : MonoBehaviour
{
    public float moveDistance = 2f; // Distance to move up and down
    public float moveSpeed = 2f; // Speed of movement

    private Vector3 startPos; // Starting position

    void Start()
    {
        startPos = transform.position + new Vector3(0f, moveDistance, 0f); // Start position is higher above the ground
    }

    void Update()
    {
        // Calculate the new position using sine function to make the object move up and down
        Vector3 newPos = startPos + new Vector3(0f, Mathf.Sin(Time.time * moveSpeed) * moveDistance, 0f);

        // Move the object to the new position
        transform.position = newPos;
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