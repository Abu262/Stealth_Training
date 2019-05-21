using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Mission()
	{
		SceneManager.LoadScene("MissionMenu");
	}
	public void Controls()
	{
		SceneManager.LoadScene("ControlMenu");
	}
	public void Credits()
	{
		SceneManager.LoadScene("CreditsMenu");
	}
	public void Quit()
	{
		print("Application has quit");
		Application.Quit();
	}
}
