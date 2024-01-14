using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    // Add a method to check if the level is available
    public bool IsLevelAvailable(int worldIndex, int levelIndex)
    {
        // Implement your logic to check level availability here
        // For example, you can use PlayerPrefs, a database, or any other method
        string LevelAvailable = "World" + worldIndex + "_Level" + levelIndex + "_Available";
        return ES3.Load<bool>(LevelAvailable, false);
    }

    public void LoadScene(string sceneName, int worldIndex, int levelIndex)
    {
        // Check if the level is available before loading the scene
        if (IsLevelAvailable(worldIndex, levelIndex))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log($"Level is not available.");
        }
    }

#if UNITY_EDITOR
    // Add a public method to load the scene directly from the inspector
    public void LoadSceneFromInspector()
    {
        // Provide default worldIndex and levelIndex values, replace with your actual values
        int defaultWorldIndex = 1;
        int defaultLevelIndex = 1;

        LoadScene(sceneToLoad, defaultWorldIndex, defaultLevelIndex);
    }
#endif
}


//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SceneLoader : MonoBehaviour
//{
//    [SerializeField]
//    private string sceneToLoad;

//    // Add a method to check if the level is available
//    public bool IsLevelAvailable(int worldIndex, int levelIndex)
//    {
//        // Implement your logic to check level availability here
//        // For example, you can use PlayerPrefs, a database, or any other method
//        string LevelAvailable = "World" + worldIndex + "_Level" + levelIndex + "_Available";
//        return ES3.Load<bool>(LevelAvailable, false);
//    }

//    public void LoadScene(string sceneName, int worldIndex, int levelIndex)
//    {
//        // Check if the level is available before loading the scene
//        if (IsLevelAvailable(worldIndex, levelIndex))
//        {
//            SceneManager.LoadScene(sceneName);
//        }
//        else
//        {
//            Debug.Log($"Cannot load scene. Level {levelIndex} is not available.");
//        }
//    }
//}



////using UnityEngine;
////using UnityEngine.SceneManagement;

////public class SceneLoader : MonoBehaviour
////{
////    [SerializeField]
////    private string sceneToLoad;
////    public void LoadScene(string sceneName)
////    {
////        SceneManager.LoadScene(sceneName);
////    }
////}
