using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public GameObject playerPrefab; // Drag and drop your player prefab here in the Unity Editor
    public string NameOfLevel;
    
    public void LoadNextLevel()
    {
        Debug.Log("Next button clicked. Loading next level...");
        SceneManager.LoadScene(NameOfLevel);
    }

    /*void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == NameOfLevel)
        {
            Debug.Log("Loading scene: " + scene.name);

            // Instantiate player prefab
            GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            Debug.Log("Player instantiated at: " + player.transform.position);
            // Optionally, you can set the player's position here
            player.transform.position = new Vector3(-7, -3, 0);
            

        }
    }*/
}
