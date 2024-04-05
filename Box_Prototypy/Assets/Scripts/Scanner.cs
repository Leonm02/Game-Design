/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Physics2D.queriesStartInColliders = false;  
    }

    // Update is called once per frame
    public float distance;
    public float rotationspeed;
    void Update()
    {
        transform.Rotate(Vector3.forward*rotationspeed*Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null){
            Debug.DrawLine ( transform.position, hitInfo.point, Color.red);
        }
        else{
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green );
        }
    }
}
*/
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float distance;
    public float rotationspeed;
    public GameObject gameOverScreen;
    private LineRenderer lineRenderer;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        // Add LineRenderer component if not already attached
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Set up LineRenderer properties
        lineRenderer.positionCount = 2; // Set the number of positions for the line renderer
    }

    void Update()
    {
    //transform.Rotate(Vector3.forward * rotationspeed * Time.deltaTime);
    // Determine the direction of the raycast (downwards)
    Vector2 rayDirection = -transform.up;

    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, rayDirection, distance);

    // Set line positions
    lineRenderer.SetPosition(0, transform.position);
    lineRenderer.SetPosition(1, hitInfo.collider != null ? hitInfo.point : (Vector2)transform.position + rayDirection * distance);

    // Set line colors
    lineRenderer.startColor = hitInfo.collider != null ? Color.red : Color.green;
    lineRenderer.endColor = hitInfo.collider != null ? Color.red : Color.green;

    // Check if the player is hit by the ray
    if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    }
}

