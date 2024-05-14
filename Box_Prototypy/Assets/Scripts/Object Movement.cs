using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform startPoint; // Start point of movement
    public Transform endPoint; // End point of movement
    public float moveSpeed = 2f; // Speed of movement

    private Vector3 startPos; // Starting position
    private Vector3 endPos; // Ending position
    private Vector3 lastPos; // Last position for determining movement direction

    void Start()
    {
        // Set the starting and ending positions based on the start and end points
        if (startPoint != null)
            startPos = startPoint.position;

        if (endPoint != null)
            endPos = endPoint.position;

        // Set the initial last position
        lastPos = transform.position;
    }

    void Update()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogError("Start or end point is not assigned.");
            return;
        }

        // Calculate the new position using sine function to make the object move up and down
        Vector3 newPos = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * moveSpeed, 1f));

        // Move the object to the new position
        transform.position = newPos;

        // Determine movement direction
        Vector3 currentPos = transform.position;
        Vector3 direction = currentPos - lastPos;

        // Flip the sprite based on movement direction
        if (direction.x > 0) // Moving to the right
        {
            transform.localScale = new Vector3((float)0.1139, (float)0.1139, (float)0.1139); // Sprite faces right
        }
        else if (direction.x < 0) // Moving to the left
        {
            transform.localScale = new Vector3((float)-0.1139, (float)0.1139, (float)0.1139); // Sprite faces left (flipped horizontally)
        }

        // Update the last position
        lastPos = currentPos;
    }

    // Draw Gizmos in the Unity Editor
    private void OnDrawGizmos()
    {
        if (startPoint != null && endPoint != null)
        {
            // Draw a line from the start to the end point
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }
}
