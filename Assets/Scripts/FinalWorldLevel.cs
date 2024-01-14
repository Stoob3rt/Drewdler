using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalWorldLevel : MonoBehaviour
{


    public int worldIndex;  // Added to distinguish between different worlds
    public int levelIndex;  // same but for levels


    void Start()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            // This saves the level availability for the next level
            ES3.Save("World" + (worldIndex + 1) + "_Level" + (levelIndex + 1) + "_Available", true);
            Debug.Log("Saved World" + (worldIndex + 1) + "_Level" + (levelIndex + 1) + "_Available" + true);


        }
    }


}