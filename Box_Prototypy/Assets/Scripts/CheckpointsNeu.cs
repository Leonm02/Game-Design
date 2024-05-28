using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsNeu : MonoBehaviour
{
    GameController gameController;
    public Transform respawnPoint;
    SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip checkpointSound; // Sound to play when the checkpoint is reached for the first time
    bool hasBeenReached = false; // Flag to track if the checkpoint has been reached before

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component

        // Debugging logs to check AudioSource and AudioClip
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the Checkpoint GameObject.");
        }
        if (checkpointSound == null)
        {
            Debug.LogError("Checkpoint sound clip is not assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the checkpoint");

            // If the checkpoint has not been reached before, play the sound
            if (!hasBeenReached)
            {
                PlayCheckpointSound();
                hasBeenReached = true; // Set the flag to true to indicate the checkpoint has been reached
            }

            gameController.UpdateCheckpoint(respawnPoint.position);
            spriteRenderer.sprite = active;
        }
    }

    void PlayCheckpointSound()
    {
        if (audioSource != null && checkpointSound != null)
        {
            Debug.Log("Playing checkpoint sound");
            audioSource.PlayOneShot(checkpointSound); // Play the checkpoint sound
        }
        else
        {
            Debug.LogWarning("Checkpoint: AudioSource or checkpointSound is not assigned.");
        }
    }
}
