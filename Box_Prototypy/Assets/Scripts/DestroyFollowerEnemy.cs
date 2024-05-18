using UnityEngine;

public class FollowerEnemyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Zerstöre den verfolgenden Gegner, wenn er den Spieler trifft
            Destroy(gameObject);
        }
    }
}
