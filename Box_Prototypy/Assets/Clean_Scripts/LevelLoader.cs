using UnityEngine;
using UnityEngine.UI;

public class ButtonLoader : MonoBehaviour
{
    public string sceneName;

    public void LoadScene()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadLevel(sceneName);
        }
        else
        {
            Debug.LogError("GameManager instance not found!");
        }
    }
}
