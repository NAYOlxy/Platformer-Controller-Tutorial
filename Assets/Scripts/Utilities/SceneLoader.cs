using UnityEngine.SceneManagement;

public class SceneLoader 
{
    public static void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);
    }

    public static void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

    public static void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        if(sceneIndex>=SceneManager.sceneCount)
        {
            ReloadScene();

            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
