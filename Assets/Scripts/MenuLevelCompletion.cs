
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelCompletion : MonoBehaviour
{

    public int worldIndex;  // Added to distinguish between different worlds
    public int levelIndex;


    void Start()
    {



        ES3.Save("World" + worldIndex + "_Level" + (levelIndex + 1) + "_Available", true);

        Debug.Log("Saving World" + worldIndex + "_Level" + levelIndex + "_Available: " + true);

    }




}