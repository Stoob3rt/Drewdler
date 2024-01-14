using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	
	
	public static bool GameIsPaused = false;
	
	public GameObject pauseMenuUI;
	
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			} else
			{
				Pause();
			}
			
		}
	}
	
	
	
	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;	
		
	}
	
	void Pause()
		
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	
	public void LoadMenu()
	{
		Time.timeScale = 1f;
		Debug.Log("Loading Menu...");
		SceneManager.LoadScene("FinalMainMenu");
	}
	
	
		public void QuitGame()
	{
		Debug.Log("Quitting Game...");
		Application.Quit();
	}
	
	
}






//using UnityEngine;
//
//public class PauseMenu : MonoBehaviour
//{
//    public GameObject pauseMenuCanvas;
//    [SerializeField]
//    private bool isPaused = false;
//
//    public bool IsPaused
//    {
//        get { return isPaused; }
//        set
//        {
//            isPaused = value;
//            pauseMenuCanvas.SetActive(isPaused);
//            Time.timeScale = isPaused ? 0f : 1f;
//        }
//    }
//
//    private void Start()
//    {
//        ResumeGame(); // Ensure the game is initially running
//    }
//
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            IsPaused = !IsPaused; // Toggle the isPaused state
//        }
//    }
//
//    private void ResumeGame()
//    {
//        IsPaused = false;
//    }
//
//    public void ResumeButtonClicked()
//    {
//        ResumeGame();
//    }
//
//    public void SettingsButtonClicked()
//    {
//        // Implement your settings functionality here
//        Debug.Log("Settings button clicked");
//    }
//
//    public void ExitButtonClicked()
//    {
//        // Implement your exit functionality here
//        Debug.Log("Exit button clicked");
//        Application.Quit(); // Quit the application
//    }
//}
