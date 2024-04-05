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

    void Start()
    {
        // Set the starting and ending positions based on the start and end points
        if (startPoint != null)
            startPos = startPoint.position;

        if (endPoint != null)
            endPos = endPoint.position;
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

