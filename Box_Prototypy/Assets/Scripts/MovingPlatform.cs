using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint; // Define the start point in the Unity Editor
    public Transform endPoint; // Define the end point in the Unity Editor
    public float moveSpeed = 3f;

    private bool movingToEnd = true; // Initially, move towards the end point

    // Draw Gizmos in the Unity Editor
    private void OnDrawGizmos()
    {
        if (startPoint != null && endPoint != null)
        {
            // Draw a line between the start and end points
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Determine the target position based on the direction
        Vector3 targetPosition = movingToEnd ? endPoint.position : startPoint.position;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the platform reaches the target position, change direction
        if (transform.position == targetPosition)
        {
            movingToEnd = !movingToEnd;
        }
    }
}



/*public class MovingPlatform : MonoBehaviour
{
    float dirX; 
    public float moveSpeed = 3f;
    bool moveRight = true;
    public float distance = 1f;
    float initialPositionX;

    // Start is called before the first frame update
    void Start()
    {
        initialPositionX = transform.position.x; // Store the initial X position
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the platform is beyond the distance from the initial position
        if(transform.position.x > initialPositionX + distance)
            moveRight = false;
        if (transform.position.x < initialPositionX - distance)
            moveRight = true;   

        // Move the platform based on the direction
        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);   
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);     
    }
}*/
