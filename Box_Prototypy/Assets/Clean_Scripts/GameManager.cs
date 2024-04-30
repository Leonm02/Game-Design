using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private string previousSceneName;
    private Vector3 playerPosition;

    // Ensure there's only one instance of GameManager
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent GameManager from being destroyed when loading new scenes
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one
        }
    }

    public static GameManager Instance
    {
        get { return instance; }
    }

    // Your GameManager functions go here

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
