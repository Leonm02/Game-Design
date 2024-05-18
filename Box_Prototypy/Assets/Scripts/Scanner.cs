using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float distance;
    public Material lineMaterial;
    public Vector2 lineOffset = Vector2.zero;
    public GameObject enemyPrefab;
    private LineRenderer lineRenderer;

    private bool enemiesSpawned = false;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 1f;

        lineRenderer.material = lineMaterial;
    }

    void Update()
    {
        Vector2 rayDirection = -transform.up;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, rayDirection, distance);

        lineRenderer.SetPosition(0, (Vector2)transform.position + lineOffset);
        lineRenderer.SetPosition(1, hitInfo.collider != null ? hitInfo.point : (Vector2)transform.position + rayDirection * distance);

        lineRenderer.startColor = hitInfo.collider != null ? Color.red : Color.green;
        lineRenderer.endColor = hitInfo.collider != null ? Color.red : Color.green;

        if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player") && !enemiesSpawned)
        {
            Debug.Log("Player entered the scanner");

            GameController playerController = hitInfo.collider.GetComponent<GameController>();
            if (playerController != null)
            {
                Debug.Log("Spawning enemies for scanner");
                GameObject enemy = SpawnEnemiesInRange(hitInfo.collider.transform.position, 3f, 5f); // Änderung hier: Bereich für y-Koordinate festlegen
                enemiesSpawned = true;
            }
        }
    }

    GameObject SpawnEnemiesInRange(Vector3 playerPosition, float minY, float maxY)
    {
        Vector3 spawnPosition = new Vector3(
            playerPosition.x + Random.Range(-5.0f, 5.0f),
            Mathf.Clamp(playerPosition.y + Random.Range(-5.0f, 5.0f), minY, maxY), // Änderung hier: sicherstellen, dass y im Bereich minY und maxY liegt
            playerPosition.z
        );
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.SetTarget(playerPosition);
        }
        return enemy;
    }
}
