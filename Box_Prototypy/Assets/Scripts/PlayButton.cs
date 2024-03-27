using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        // Load the game scene when the play button is clicked
        SceneManager.LoadScene(sceneName);
    }
}

