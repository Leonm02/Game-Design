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

}
