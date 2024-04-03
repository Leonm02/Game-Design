using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    // Start is called before the first frame update
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

}
