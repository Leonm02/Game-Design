using UnityEngine;

public class Keeker : MonoBehaviour
{
    public float inactiveDuration = 5f; // Duration of inactivity
    public float activeDuration = 3f; // Duration of activity
    public float detectionRadius = 1.5f; // Radius for detection
    public Color activeColor = Color.red; // Color when active
    public Color inactiveColor = Color.white; // Color when inactive
    public Sprite activeSprite; // Sprite when active
    public Sprite inactiveSprite; // Sprite when inactive
    public GameObject gameOverScreen; // Reference to the game over screen

    private bool isActive = false; // Flag to track if enemy is active
    private float timer = 0f; // Timer for duration
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = inactiveColor; // Set initial color to inactive color
        spriteRenderer.sprite = inactiveSprite; // Set initial sprite to inactive sprite
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (isActive)
        {
            // Change color to active color
            spriteRenderer.color = activeColor;
            spriteRenderer.sprite = activeSprite; // Change sprite to active sprite

            if (timer <= 0f)
            {
                isActive = false;
                timer = inactiveDuration;
                spriteRenderer.color = inactiveColor; // Change color back to inactive color
                spriteRenderer.sprite = inactiveSprite; // Change sprite back to inactive sprite
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
    }

    // Check for collisions with the player when the enemy becomes active
    void OnTriggerStay2D(Collider2D other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            // Destroy the player
            Destroy(other.gameObject);

            // Trigger game over screen
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
