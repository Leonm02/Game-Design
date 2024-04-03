using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject gameOverScreen; // Reference to the game over screen GameObject

    void Start()
    {
        // Deactivate the game over screen GameObject at the start
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the player GameObject
            Destroy(other.gameObject);

            // Show the game over screen GameObject
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }

            // You can add additional game over logic here if needed
            Debug.Log("Player destroyed - Game Over!");
        }
    }
}
