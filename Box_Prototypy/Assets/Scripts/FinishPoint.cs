using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player.
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the finish point.");
            // Load the Level Complete scene.
            SceneManager.LoadScene("LevelComplete");
        }
    }
}
