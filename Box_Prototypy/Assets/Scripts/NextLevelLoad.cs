using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public string NameOfLevel;
    
    public void LoadNextLevel()
    {
        Debug.Log("Next button clicked. Loading next level...");
        SceneManager.LoadScene(NameOfLevel);
    }

}
