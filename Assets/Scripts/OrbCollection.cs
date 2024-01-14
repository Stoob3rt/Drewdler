//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class OrbCollection : MonoBehaviour
//{
//    public Text orbCountText; // Reference to the UI text element
//    private HashSet<GameObject> collectedOrbs = new HashSet<GameObject>();
//    private HighScore highScoreScript;
//    public int levelIndex;
//    public int orbsCollected;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Initialize the highScoreScript by finding it in the scene
//        highScoreScript = FindObjectOfType<HighScore>();
//        if (highScoreScript == null)
//        {
//            Debug.LogError("HighScore script not found in the scene.");
//        }

//        // Reset orbs collected to the value loaded from ES3 using the levelIndex
//        highScoreScript.orbsCollected = ES3.Load("Level" + levelIndex + "_OrbsCollected", 0);

//        // Update the UI text with the orbs collected from ES3
//        UpdateOrbCountText();
//    }

//    // Change from OnTriggerEnter to OnTriggerEnter2D, and use Collider2D
//    private void OnTriggerEnter2D(Collider2D Col)
//    {
//        if (Col.gameObject.CompareTag("Orbs") && !collectedOrbs.Contains(Col.gameObject))
//        {
//            // Add the collected orb to the list
//            collectedOrbs.Add(Col.gameObject);
//            Col.gameObject.SetActive(false);

//            // Calculate the new orbs collected count
//            orbsCollected = collectedOrbs.Count; // Update the orbsCollected count

//            // Load the previously saved orbs collected count
//            int previousOrbsCollected = ES3.Load("Level" + levelIndex + "_OrbsCollected", 0);

//            // Check if the new count is greater than the previously collected count
//         //   if (orbsCollected > previousOrbsCollected)
//         //   {
//                // Save the updated orbs collected to ES3 using the level index
//         //       ES3.Save("Level" + levelIndex + "_OrbsCollected", orbsCollected);
//         //       Debug.Log("Saving level " + levelIndex + "_OrbsCollected: " + orbsCollected);
//         //   }

//            // Update the UI text with the new orb count
//            UpdateOrbCountText();
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        // Check if the collided GameObject has the "Finish" tag
//        if (collision.gameObject.CompareTag("Finish"))
//        {
//            // Load the previously saved 3 collected count
//            int previousOrbsCollected = ES3.Load("Level" + levelIndex + "_OrbsCollected", 0);

//            Debug.Log("Loaded level " + levelIndex + "_OrbsCollected: " + previousOrbsCollected);

//            // Check if the current orbsCollected count is greater than the loaded count
//            if (orbsCollected > previousOrbsCollected)
//            {
//                // Save the updated orbs collected to ES3 using the level index
//                ES3.Save("Level" + levelIndex + "_OrbsCollected", orbsCollected);
//                Debug.Log("Saving level " + levelIndex + "_OrbsCollected: " + orbsCollected);
//            }
//            else
//            {
//                Debug.Log("Not saving level " + levelIndex + "_OrbsCollected because it's not greater than the loaded count.");
//            }
//        }
//    }

//    void UpdateOrbCountText()
//    {
//        // Update the UI text with the current orbs collected in this level
//        orbCountText.text = orbsCollected.ToString();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }
//}



using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbCollection : MonoBehaviour
{
    public Text orbCountText;
    private HashSet<GameObject> collectedOrbs = new HashSet<GameObject>();
    private HighScore highScoreScript;
    public int worldIndex;  // Added to distinguish between different worlds
    public int levelIndex;  // same but for levels
    public int orbsCollected;

    void Start()
    {
        highScoreScript = FindObjectOfType<HighScore>();
        if (highScoreScript == null)
        {
            Debug.LogError("HighScore script not found in the scene.");
        }

        // Reset orbs collected to the value loaded from ES3 using the worldIndex and levelIndex
        highScoreScript.orbsCollected = ES3.Load("World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected", 0);

        UpdateOrbCountText();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Orbs") && !collectedOrbs.Contains(col.gameObject))
        {
            collectedOrbs.Add(col.gameObject);
            col.gameObject.SetActive(false);

            orbsCollected = collectedOrbs.Count;

            int previousOrbsCollected = ES3.Load("World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected", 0);

            UpdateOrbCountText();

            // Check if all orbs in the current world are collected
            //if (AreAllOrbsCollected())
            //{
                // Switch to the final state to unlock the next world or perform other actions
            //    FSMManager.instance.SetGameState(FSMManager.GameState.FinalLevelUnlocked);
            //}
        }
    }

    private bool AreAllOrbsCollected()
    {
        int totalOrbs = 0;

        // Calculate the total number of orbs for the current world (assuming 3 orbs per level)
        for (int i = 1; i <= 12; i++)
        {
            totalOrbs += ES3.Load("World" + worldIndex + "_Level" + i + "_OrbsCollected", 0);
        }

        // Check if the collected orbs equal the total orbs for the current world
        return orbsCollected == totalOrbs;
    }

    private void UpdateOrbCountText()
    {
        orbCountText.text = orbsCollected.ToString();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Finish"))
    //    {
    //        int previousOrbsCollected = ES3.Load("World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected", 0);

    //        Debug.Log("Loaded World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected: " + previousOrbsCollected);

    //        if (orbsCollected > previousOrbsCollected)
    //        {
    //            //ES3.Save("World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected", orbsCollected);
    //            Debug.Log("Saving World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected: " + orbsCollected);
    //        }
    //        else
    //        {
    //            Debug.Log("Not saving World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected because it's not greater than the loaded count.");
    //        }
    //    }
    //}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            // Reduces the size of the player when colliding with the portal
            float scaleFactor = 0.1f; // Adjust the scale factor as needed
            transform.localScale = new Vector3(transform.localScale.x * scaleFactor, transform.localScale.y * scaleFactor, 1f);


            int previousOrbsCollected = ES3.Load("World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected", 0);
            bool isLevelCompleted = ES3.Load("World" + worldIndex + "_Level" + levelIndex + "_Completed", false);
            // This saves the level availability for the next level
            ES3.Save("World" + worldIndex + "_Level" + (levelIndex + 1) + "_Available", true);
            Debug.Log("Loaded World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected: " + previousOrbsCollected);

            if (orbsCollected > previousOrbsCollected)
            {
                // Save orbs collected
                ES3.Save("World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected", orbsCollected);
                Debug.Log("Saving World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected: " + orbsCollected);

                // Save level completion status
                ES3.Save("World" + worldIndex + "_Level" + levelIndex + "_Completed", true);
               
                Debug.Log("Saving World" + worldIndex + "_Level" + levelIndex + "_Completed: " + true);
            }
            else
            {
                Debug.Log("Not saving World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected because it's not greater than the loaded count.");
            }
        }
    }


}