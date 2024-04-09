using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string NameOfScene; // Name of the scene you want to load

    public void LoadScene()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(NameOfScene); // Load the specified scene
    }
}
