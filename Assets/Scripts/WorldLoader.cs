using System;
using UnityEngine;
using UnityEngine.UI;

public class WorldLoader : MonoBehaviour
{
    [SerializeField] private Button previousbutton;
    [SerializeField] private Button nextbutton;
    private int currentWorld;

    public void Awake()
    {
        LoadNextWorld(0);
    }

    private void LoadNextWorld(int _index)
    {
        previousbutton.interactable = (_index != 0);
        nextbutton.interactable = (_index != transform.childCount-1);
        for (int i = 0; i < transform.childCount; i++)

        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }
    public void ChangeWorld(int _change)

    { 
        currentWorld += _change;
        LoadNextWorld(currentWorld);
            
            }

}
