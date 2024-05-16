using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Manager gameManager;

    void Start()
    {
        // Find the Manager in the scene
        gameManager = FindObjectOfType<Manager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Call the GameOver function from the Manager script
        if (collision.transform.tag == ("Enemy"))
        {
            Debug.Log("Enemy Collision detected.");
            gameManager.GameOver();
        }

        if (collision.transform.tag == ("Finish Point"))
        {
            Debug.Log("Finish Point Collision detected.");
            gameManager.LevelComplete();
        }
    }
}
