using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

        public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

        public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

}
