using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}