using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	private static PlayerManager instance;

	public int lives = 3;
	private float maxStamina = 2;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
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
	public Transform lastCheckPointPos;

	public void SetPlayerToCheckpoint()
	{
		GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos.position;
	}

	public void GameOver()
	{
		Debug.Log("Game over");
		//Destroy(GameObject.FindGameObjectWithTag("Player"));
		SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
		//GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Died();
	}


	public void ResetScene()
	{
		lives -= 1;
		if (lives <= 0)
		{
			Destroy(GameObject.FindGameObjectWithTag("Player"));
			GameOver();
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Died();
		}

	}

	public void BackToMenu()
	{
		//ToDo: Implement Menu scene
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadNextLevel(int scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
