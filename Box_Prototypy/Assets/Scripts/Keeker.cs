using UnityEngine;

public class Keeker : MonoBehaviour
{
    public float inactiveDuration = 5f; // Duration of inactivity
    public float activeDuration = 3f; // Duration of activity
    public Color activeColor = Color.red; // Color when active
    public Color inactiveColor = Color.white; // Color when inactive
    public GameObject gameOverScreen; // Reference to the game over screen

    private bool isActive = false; // Flag to track if enemy is active
    private float timer = 0f; // Timer for duration
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = inactiveColor; // Set initial color to inactive color
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (isActive)
        {
            // Change color to active color
            spriteRenderer.color = activeColor;

            if (timer <= 0f)
            {
                isActive = false;
                timer = inactiveDuration;
                spriteRenderer.color = inactiveColor; // Change color back to inactive color
            }
        }
        else
        {
            if (timer <= 0f)
            {
                isActive = true;
                timer = activeDuration;
            }
        }

        // Check for collisions with the player
        if (isActive)
        {
            // Check if the player enters the enemy's collider
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // Player collided with active enemy, trigger game over screen
                    gameOverScreen.SetActive(true);
                    Time.timeScale = 0f;
                    return; // Exit loop once player is detected
                }
            }
        }
    }
}
