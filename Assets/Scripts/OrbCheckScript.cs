using UnityEngine;

public class OrbCheckScript : MonoBehaviour
{
    public int worldIndex = 1;
    public int numberOfLevels = 13;
    public int thresholdValue = 36;

    void Awake()
    {
        int sumOfOrbs = 0;

        // Iterate through all levels in World1
        for (int i = 1; i <= numberOfLevels; i++)
        {
            // Construct the key for each level
            string key = "World" + worldIndex + "_Level" + i + "_OrbsCollected";

            // Load the orbs collected for the current level
            int orbsCollected = ES3.Load<int>(key, 0);

            // Add the orbs collected to the sum
            sumOfOrbs += orbsCollected;
        }

        // Check if the sum of orbs is above or equal to the threshold
        if (sumOfOrbs <= thresholdValue)
        {
            Debug.Log($"The sum of World1 orbs ({sumOfOrbs}) is LESS or equal to the threshold. Destroying GameObject.");
            Destroy(gameObject); // Destroy the GameObject this script is attached to
        }
        else
        {
            Debug.Log($"The sum of World1 orbs ({sumOfOrbs}) is ABOVE the threshold. Doing nothing.");
        }
    }
}


