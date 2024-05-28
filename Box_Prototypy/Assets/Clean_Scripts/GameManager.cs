using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject levelCompleteMenu;

    public AudioClip levelCompleteSound;  // Level-Complete-Sound
    public AudioClip nextLevelMusic;      // Musik, die nach dem Level-Complete-Sound abgespielt werden soll
    public AudioSource musicSource;       // Quelle für die Hintergrundmusik
    private AudioSource sfxSource;        // Quelle für Soundeffekte

    public bool isPaused;
    public bool gameOver;
    public bool levelComplete;

    void Start()
    {
        // Ensure pauseMenu is initially inactive
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        levelCompleteMenu.SetActive(false);

        // Fügen Sie eine AudioSource-Komponente für Soundeffekte hinzu
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Überprüfen Sie, ob die Musikquelle vorhanden ist
        if (musicSource == null)
        {
            Debug.LogError("MusicSource is not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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

    public void LevelComplete()
    {
        Debug.Log("LevelComplete() method called.");
        levelCompleteMenu.SetActive(true);
        Time.timeScale = 0f;
        levelComplete = true;

        if (musicSource != null)
        {
            musicSource.Stop();  // Stoppen Sie die Hintergrundmusik
        }

        if (sfxSource != null && levelCompleteSound != null)
        {
            Debug.Log("Playing level complete sound.");
            sfxSource.PlayOneShot(levelCompleteSound);
            StartCoroutine(PlayNextLevelMusicAfterSound(levelCompleteSound.length));  // Starten Sie die Coroutine
        }
        else
        {
            Debug.LogError("SFXSource or LevelCompleteSound is missing!");
        }
    }

    private IEnumerator PlayNextLevelMusicAfterSound(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);  // Warten Sie, bis der Level-Complete-Sound abgespielt wurde
        if (musicSource != null && nextLevelMusic != null)
        {
            musicSource.clip = nextLevelMusic;
            musicSource.Play();
        }
        else
        {
            Debug.LogError("MusicSource or NextLevelMusic is missing!");
        }
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1f;
        levelComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }
}
