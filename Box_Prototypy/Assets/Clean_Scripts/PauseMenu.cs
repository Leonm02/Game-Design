using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    void Start()
    {
        // Ensure pauseMenu is initially inactive
        pauseMenu.SetActive(false);
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

    public void GoToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }
}