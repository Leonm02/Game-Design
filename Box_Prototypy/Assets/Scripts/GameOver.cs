using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen; // Reference to the game over screen GameObject
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
