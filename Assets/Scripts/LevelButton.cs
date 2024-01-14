using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IPointerClickHandler
{
    public int worldIndex = 1;
    public int levelIndex;
    public float maxRandomMoveDistance = 1f;
    public int orbsCollected;

    public Vector2 moveDirection = new Vector2(1f, 1f);

    private bool isLevelCompleted;
    private bool isLevelAvailable;
    private Button button;

    [SerializeField]
    private SceneLoader sceneLoader; // Reference to the SceneLoader script

    [SerializeField]
    private string sceneName; // Exposed field to set the scene name in the Unity Editor

    void Start()
    {
        // Load the completed status for each level
        string completedKey = "World" + worldIndex + "_Level" + levelIndex + "_Completed";
        isLevelCompleted = ES3.Load<bool>(completedKey, false);

        // Load the availability level
        string LevelAvailable = "World" + worldIndex + "_Level" + levelIndex + "_Available";
        isLevelAvailable = ES3.Load<bool>(LevelAvailable, false);

        // Load the orbs collected for each level
        string key = "World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected";
        orbsCollected = ES3.Load(key, 0);

        Debug.Log($"Loaded keys for Level {levelIndex}: Available = {isLevelAvailable}, IsCompleted = {isLevelCompleted}, OrbsCollected = {orbsCollected}");

        button = GetComponent<Button>(); // Assuming the Button component is attached to the same GameObject

        if (isLevelCompleted)
        {
            ResetLevelPosition();
        }
        else
        {
            MoveLevelAway();
        }
    }


    void ResetLevelPosition()
    {
        // This moves the objects away from each other
        transform.Translate(new Vector3(moveDirection.x * maxRandomMoveDistance, moveDirection.y * maxRandomMoveDistance, 0f), Space.World);

        // This transforms the level back to the middle if it's completed
        Tween.LocalPosition(transform, endValue: Vector3.zero, duration: 3f, Ease.OutSine);
    }


    void MoveLevelAway()
    {
        // Set the color of the Image component to hexadecimal 727272
        Image image = GetComponent<Image>();
        if (image != null)
        {
            // Convert hexadecimal (0x727272) to RGB values (114, 114, 114) and then normalize to values between 0 and 1
            Color tintedColor = new Color(114 / 255f, 114 / 255f, 114 / 255f);
            image.color = tintedColor;
        }

        // Use Translate to move the object on both x and y axes using the specified moveDirection
        transform.Translate(new Vector3(moveDirection.x * maxRandomMoveDistance, moveDirection.y * maxRandomMoveDistance, 0f), Space.World);
        Tween.Scale(transform, endValue: new Vector3(x: .36f, y: 0.36f, z: .36f), duration: 1f, Ease.OutSine, cycles: -1, CycleMode.Rewind);
    }


    // Implement the IPointerClickHandler interface
    // Implement the IPointerClickHandler interface
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isLevelAvailable)
        {
            Debug.Log($"Level {levelIndex} clicked!");

            // Load the scene using the SceneLoader
            if (sceneLoader != null)
            {
                // Use the sceneName specified in the Unity Editor for this button
                sceneLoader.LoadScene(sceneName, worldIndex, levelIndex);
            }
        }
        else
        {
           // Debug.Log($"Cannot click. Level {levelIndex} is not available.");

            if (button != null)
            {
                button.interactable = false;
                button.enabled = false;

                Image image = button.GetComponent<Image>();
                if (image != null)
                {
                    Color transparentColor = image.color;
                    transparentColor.a = .5f;
                    image.color = transparentColor;
                }
            }
        }
    }
}





//using PrimeTween;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class LevelButton : MonoBehaviour, IPointerClickHandler
//{
//    public int worldIndex = 1; // Adjust this according to your needs
//    public int levelIndex; // Assign this in the inspector for each button
//    public float maxRandomMoveDistance = 1f; // Adjust this according to your needs
//    public int orbsCollected;

//    [Header("Inspector-Controlled Movement")]
//    public Vector2 moveDirection = new Vector2(1f, 1f); // You can adjust this in the inspector

//    private bool isLevelCompleted;
//    private bool isLevelAvailable;
//    private SceneLoader sceneLoader;
//    private Button button;

//    void Start()
//    {
//        // Load the completed status for the each level
//        string completedKey = "World" + worldIndex + "_Level" + levelIndex + "_Completed";
//        isLevelCompleted = ES3.Load<bool>(completedKey, false);

//        // Load the availability level
//        string LevelAvailable = "World" + worldIndex + "_Level" + levelIndex + "_Available";
//        isLevelAvailable = ES3.Load<bool>(LevelAvailable, false);
//        sceneLoader = GetComponent<SceneLoader>();
//        // Check if the key exists before loading its value
//        if (ES3.KeyExists(LevelAvailable))
//        {
//            isLevelAvailable = ES3.Load<bool>(LevelAvailable);
//        }
//        else
//        {
//            isLevelAvailable = false; // Set a default value if the key doesn't exist
//        }

//        // Load the orbs collected for each level
//        string key = "World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected";
//        orbsCollected = ES3.Load(key, 0);

//        Debug.Log($"Loaded keys for Level {levelIndex}: Available = {isLevelAvailable}, IsCompleted = {isLevelCompleted}, OrbsCollected = {orbsCollected}");

//        button = GetComponent<Button>(); // Assuming the Button component is attached to the same GameObject

//        if (isLevelCompleted)
//        {
//            // Move the level to its original state (you might need to adjust this logic)
//            ResetLevelPosition();
//        }
//        else
//        {
//            // Move the level away from its original location
//            MoveLevelAway();
//        }
//    }

//    void ResetLevelPosition()
//    {
//        // This moves the objects away from each other
//        transform.Translate(new Vector3(moveDirection.x * maxRandomMoveDistance, moveDirection.y * maxRandomMoveDistance, 0f), Space.World);

//        // This transforms the level back to the middle if it's completed
//        Tween.LocalPosition(transform, endValue: Vector3.zero, duration: 3f, Ease.OutSine);
//    }

//    void MoveLevelAway()
//    {
//        // Set the color of the Image component to hexadecimal 727272
//        Image image = GetComponent<Image>();
//        if (image != null)
//        {
//            // Convert hexadecimal (0x727272) to RGB values (114, 114, 114) and then normalize to values between 0 and 1
//            Color tintedColor = new Color(114 / 255f, 114 / 255f, 114 / 255f);
//            image.color = tintedColor;
//        }

//        // Use Translate to move the object on both x and y axes using the specified moveDirection
//        transform.Translate(new Vector3(moveDirection.x * maxRandomMoveDistance, moveDirection.y * maxRandomMoveDistance, 0f), Space.World);
//        Tween.Scale(transform, endValue: new Vector3(x: .36f, y: 0.36f, z: .36f), duration: 1f, Ease.OutSine, cycles: -1, CycleMode.Rewind);
//    }


//    // Implement the IPointerClickHandler interface
//    public void OnPointerClick(PointerEventData eventData)
//    {
//        // Check if the level is completed before allowing the click
//        if (isLevelAvailable)
//        {
//            Debug.Log($"Level {levelIndex} clicked!");

//            // If SceneLoader script is attached, load the scene
//            if (sceneLoader != null)
//            {
//                sceneLoader.LoadScene();
//            }
//        }
//        else
//        {
//            Debug.Log($"Cannot click. Level {levelIndex} is not available.");

//            // Disable the button
//            if (button != null)
//            {
//                button.interactable = false;
//            }
//        }




//    }

//}




