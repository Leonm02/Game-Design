using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    

    void Start()
    {
        // Find the Manager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Call the GameOver function from the Manager script
        /*if (collision.transform.tag == ("Enemy"))
        {
            Debug.Log("Enemy Collision detected.");
            gameManager.GameOver();
        }*/

        if (collision.transform.tag == ("Finish Point"))
        {
            Debug.Log("Finish Point Collision detected.");
            gameManager.LevelComplete();
                        Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.OnFlagTouch();
            }
            else
            {
                Debug.LogError("PlayerCollisions: Timer script not found.");
            }
        }
    }

}
