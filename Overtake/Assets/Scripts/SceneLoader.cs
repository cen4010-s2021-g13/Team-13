using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	//Load Main Menu
	public void LoadMenu()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
	//Load Next Level
	public void LoadGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	//Reload Current Level
	public void ReloadGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);		
	}
	//Quit Game
	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quitting Game");
	}
}
