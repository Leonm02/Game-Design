using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
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
            // You can add your game over logic here, like showing a game over screen, resetting the level, etc.
            Debug.Log("Player destroyed - Game Over!");
        }
    }
}