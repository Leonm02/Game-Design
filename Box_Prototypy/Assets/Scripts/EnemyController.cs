using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2.0f;
    public float avoidDistance = 1.0f; // Minimaler Abstand zu anderen Gegnern
    public float avoidSpeed = 1.5f; // Geschwindigkeit, um Abstand zu halten
    private Transform target;

    public void SetTarget(Vector3 targetPosition)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        // Abstand zu anderen Gegnern halten
        AvoidOtherEnemies();
    }

    void AvoidOtherEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, avoidDistance);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject && hit.CompareTag("Enemy"))
            {
                Vector3 avoidDirection = (transform.position - hit.transform.position).normalized;
                transform.position += avoidDirection * avoidSpeed * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy collided with: " + collision.gameObject.name);
        if (collision.CompareTag("Player"))
        {
            // Get the GameController component from the player
            GameController playerController = collision.GetComponent<GameController>();
            if (playerController != null)
            {
                // Call the Die method
                playerController.Die();
            }
        }
    }
}
