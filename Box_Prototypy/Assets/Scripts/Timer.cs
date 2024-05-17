using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // Time limit in seconds
    public Text timerText; // Reference to the UI text component displaying the timer
    public GameObject player; // Reference to the player GameObject
    public GameObject gameOverScreen; // Reference to the game over screen GameObject
    public GameObject alarmScreen; // Reference to the alarm screen GameObject
    public float blinkInterval = 0.5f; // Interval for blinking

    public static float currentTime; // Current time left
    private bool isGameOver = false; // Flag to check if the game is over
    private bool isBlinking = false; // Flag to check if the alarm screen is currently blinking

    private void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("Timer: Text component is not assigned. Please assign a Text component to the Timer script.");
        }

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); // Deactivate the game over screen at the start
        }
        else
        {
            Debug.LogWarning("Timer: Game Over Screen GameObject is not assigned. Please assign a GameObject to the gameOverScreen variable in the Timer script.");
        }

        currentTime = timeLimit;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f) // Check if time is up
            {
                currentTime = 0f; // Ensure the timer does not go below zero
                GameOver();
            }
            UpdateTimerDisplay();

            // Check if blinking should start
            if (!isBlinking && currentTime <= 10f)
            {
                isBlinking = true;
                StartCoroutine(BlinkCoroutine()); // Start blinking coroutine
            }
        }
    }

    private IEnumerator BlinkCoroutine()
    {
        while (isBlinking && !isGameOver) // Check if blinking should continue and the game is not over
        {
            alarmScreen.SetActive(!alarmScreen.activeSelf); // Toggle visibility
            yield return new WaitForSeconds(blinkInterval);

            // Adjust blink interval based on remaining time
            if (currentTime <= 5f)
            {
                blinkInterval = 0.1f; // Faster blinking
            }
            else if (currentTime <= 10f)
            {
                blinkInterval = 0.5f; // Slower blinking
            }
        }

        if (isGameOver)
        {
            // Ensure alarm screen is turned off when the game is over
            alarmScreen.SetActive(false);
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (timerText != null)
            timerText.text = timerString;
        else
            Debug.LogError("Timer: Text component is not assigned. Please assign a Text component to the Timer script.");
    }

    private void GameOver()
    {
        isGameOver = true;
        // Implement your game over logic here
        Debug.Log("Game Over!");
        
        // Deactivate the player GameObject
        if (player != null)
        {
            player.SetActive(false);
            Debug.Log("Player disappeared!");
        }
        else
        {
            Debug.LogWarning("Timer: Player GameObject is not assigned. Please assign a GameObject to the player variable in the Timer script.");
        }

        // Enable the game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Timer: Game Over Screen GameObject is not assigned. Please assign a GameObject to the gameOverScreen variable in the Timer script.");
        }
    }

    public void PunishmentTime(float punishmentSeconds)
    {
        if (!isGameOver)
        {
            currentTime -= punishmentSeconds;
            if (currentTime <= 0f)
            {
                currentTime = 0f; // Ensure the timer does not go below zero
                GameOver();
            }
            UpdateTimerDisplay();
        }
    }

    public void ResetTimer()
    {
        if (!isGameOver)
        {
            currentTime = timeLimit;
            UpdateTimerDisplay();
        }
    }
}
