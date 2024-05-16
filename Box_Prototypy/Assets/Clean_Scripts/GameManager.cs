using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject gameOverMenu;

    public GameObject levelCompleteMenu;
    public bool isPaused;

    public bool gameOver;

    public bool levelComplete;

    void Start()
    {
        // Ensure pauseMenu is initially inactive
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        levelCompleteMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }    
    }

    public void PauseGame()
    {   
        // Activate pauseMenu and pause the game
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;  
    }

    public void ResumeGame()
    {
        // Deactivate pauseMenu and resume the game
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;       
    }

       public void GameOver()
    {
        // Activate gameOverMenu and stop the game
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        gameOver = true;
    }

    public void Restart()
    {
        // Deactivate gameOverMenu and reload the current scene
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelComplete(){
        levelCompleteMenu.SetActive(true);
        Time.timeScale = 0f;
        levelComplete = true;
    }

    public void GoToNextLevel(){
        Time.timeScale = 1f;
        levelComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void GoToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }
}