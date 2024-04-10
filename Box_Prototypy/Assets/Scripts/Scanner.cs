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
        // Determine if the game over screen is active
        bool gameOverActive = gameOverScreen.activeSelf;

        // If game over screen is active, disable LineRenderer and return
        if (gameOverActive)
        {
            lineRenderer.enabled = false;
            return;
        }
        else
        {
            // If game over screen is not active, enable LineRenderer
            lineRenderer.enabled = true;
        }

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
            Destroy(hitInfo.collider.gameObject);
            gameOverScreen.SetActive(true);
        }
    }
}
