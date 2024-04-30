using UnityEngine;
using UnityEngine.UI;

public class ButtonLoader : MonoBehaviour
{
    public string sceneName;

    public void LoadScene()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.LoadLevel(sceneName);
        }
        else
        {
            Debug.LogError("GameManager instance not found!");
        }
    }
}
