//using UnityEngine;
//using UnityEngine.UI;

//public class HighScore : MonoBehaviour
//{
//    public int worldIndex; // Unique identifier for the world
//    public int levelIndex; // Unique identifier for the level (e.g., 1 for Level1, 2 for Level2, etc.)
//    public Text HighOrbCountText;
//    public int orbsCollected;

//    private void Awake()
//    {
//        // Load the orbs collected for this level from ES3
//        string key = "World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected";
//        int orbsCollected = ES3.Load(key, 0);

//        // Print out the key for debugging
//        Debug.Log("Loaded " + key + " = " + orbsCollected);

//        HighOrbCountText.text = orbsCollected.ToString();
//    }

//    // Call this method to update the orbs collected for this level
//    public void UpdateOrbsCollected(int newOrbs)
//    {
//        string key = "World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected";
//        int orbsCollected = ES3.Load(key, 0);

//        if (newOrbs >= orbsCollected) // Only update if new orbs >= current orbs
//        {
//            int difference = newOrbs - orbsCollected;

//            orbsCollected = newOrbs;

//            // Save the updated orbs collected to ES3
//            ES3.Save(key, orbsCollected);
//            Debug.Log("Saving " + key + " = " + orbsCollected);
//        }
//    }
//}



using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int worldIndex; // Unique identifier for the world
    public int levelIndex; // Unique identifier for the level (e.g., 1 for Level1, 2 for Level2, etc.)
    public int orbsCollected;
    public Text HighOrbCountText;

    private void Awake()
    {
        // Load the orbs collected for this level from ES3
        string key = "World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected";
        orbsCollected = ES3.Load(key, 0);



        // Print out the key for debugging
        Debug.Log("Loaded " + key + " = " + orbsCollected);

        HighOrbCountText.text = orbsCollected.ToString();
    }

    // Call this method to update the orbs collected for this level
    public void UpdateOrbsCollected(int newOrbs)
    {
        if (newOrbs >= orbsCollected) // Only update if new orbs >= current orbs
        {
            int difference = newOrbs - orbsCollected;

            orbsCollected = newOrbs;

            // Save the updated orbs collected to ES3
            string key = "World" + worldIndex + "_Level" + levelIndex + "_OrbsCollected";
            ES3.Save(key, orbsCollected);
            Debug.Log("Saving " + key + " = " + orbsCollected);

        }
    }
}




//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.UI;

//using HutongGames.Utility;

//public class HighScore : MonoBehaviour
//{
//    public int levelIndex; // Unique identifier for the level (e.g., 1 for Level1, 2 for Level2, etc.)
//    public int orbsCollected;
//    public Text HighOrbCountText;

//    private void Awake()
//    {
//        // Create a key for saving and loading
//        string key = "Level" + levelIndex + "_OrbsCollected";

//        // Load the orbs collected for this level from ES3 using the key
//        orbsCollected = ES3.Load(key, 0);

//        // Print out the key for debugging
//        Debug.Log("Loaded " + key + " = " + orbsCollected);


//        HighOrbCountText.text = orbsCollected.ToString();
//    }

//    // Call this method to update the orbs collected for this level
//    public void UpdateOrbsCollected(int newOrbs)
//    {
//        if (newOrbs >= orbsCollected) // Only update if new orbs >= current orbs
//        {
//            orbsCollected = newOrbs;
//        }
//    }

// OnTriggerEnter2D is called when the player collides with a trigger collider
//  public void Collision2D(Collider2D other)
//  {
//      if (other.CompareTag("Finish"))
//      {
// Debug message to check if this block is reached
//          Debug.Log("Player collided with Finish");

// Save the updated orbs collected to ES3 using the level index
//           ES3.Save("Level" + levelIndex + "_OrbsCollected", orbsCollected);
//           Debug.Log("Saved " + levelIndex + "_OrbsCollected");
//       }
//   }

//   private void OnTriggerEnter2D(Collider2D other)
//   {
//       if (other.CompareTag("Finish"))
//     {
// Save the updated orbs collected to ES3 using the level index
//       ES3.Save("Level" + levelIndex + "_OrbsCollected", orbsCollected);
//       Debug.Log("Saved " + levelIndex + "_OrbsCollected");
//   }
//   }

// }
