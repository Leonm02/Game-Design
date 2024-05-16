using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Timer timer; // Reference to the Timer script
    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        checkpointPos = transform.position;

        if (timer == null)
        {
            Debug.LogError("GameController: Timer component is not assigned. Please assign the Timer component in the inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    public void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        spriteRenderer.enabled = true;

        // Reset the timer
        if (timer != null)
        {
            timer.ResetTimer();
        }
        else
        {
            Debug.LogError("GameController: Timer component is not assigned. Please assign the Timer component in the inspector.");
        }
    }
}
