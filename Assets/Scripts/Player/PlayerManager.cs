using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	private static PlayerManager instance;

	private void Awake()
	{
		instance = this;
		DontDestroyOnLoad(instance);
	}

	public static PlayerManager Instance
	{
		get
		{
			if (!instance)
		{
				//instance = new PlayerManager();
				DontDestroyOnLoad(instance);
			}

			return instance;
		}
	}
	// player stats somewhere

	// playerspawner

	// keep track of checkPoints
	public Vector2 lastCheckPointPos;

	public void ResetScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void BackToMenu()
	{
		//ToDo: Implement Menu scene
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
