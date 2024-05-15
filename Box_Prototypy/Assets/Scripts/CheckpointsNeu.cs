using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsNeu : MonoBehaviour
{
    GameController gameController;
    public Transform respawnPoint;
    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.UpdateCheckpoint(respawnPoint.position);
            spriteRenderer.sprite = active;
        }
    }
}
