using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        // Editor-Modus beenden
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Anwendung beenden
        Application.Quit();
        #endif
    }
}