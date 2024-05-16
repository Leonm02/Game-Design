using UnityEngine;

public class Keeker : MonoBehaviour
{
    public float inactiveDuration = 5f;
    public float activeDuration = 3f;
    public float detectionRadius = 1.5f;
    public Color activeColor = Color.red;
    public Color inactiveColor = Color.white;
    public Sprite activeSprite;
    public Sprite inactiveSprite;

    private bool isActive = false;
    private float timer = 0f;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D detectionCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectionCollider = gameObject.AddComponent<CircleCollider2D>();
        detectionCollider.isTrigger = true;
        detectionCollider.radius = detectionRadius;

        SetInactiveState();
        timer = inactiveDuration;

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (isActive)
        {
            if (timer <= 0f)
            {
                SetInactiveState();
                timer = inactiveDuration;
            }
        }
        else
        {
            if (timer <= 0f)
            {
                SetActiveState();
                timer = activeDuration;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            // Trigger the player's death sequence
           GameController playerController = other.GetComponent<GameController>();
            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            // Trigger the player's death sequence
            GameController playerController = other.GetComponent<GameController>();
            if (playerController != null)
            {
                playerController.Die();
            }

        }
    }

    private void SetActiveState()
    {
        isActive = true;
        spriteRenderer.color = activeColor;
        spriteRenderer.sprite = activeSprite;
    }

    private void SetInactiveState()
    {
        isActive = false;
        spriteRenderer.color = inactiveColor;
        spriteRenderer.sprite = inactiveSprite;
    }
}
