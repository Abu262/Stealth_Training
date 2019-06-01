using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;


		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void LevelSelector(string name)
	{
		 name = EventSystem.current.currentSelectedGameObject.name;
		SceneManager.LoadScene(name);
	}
	public void Quit()
	{

		Application.Quit();
	}
}