using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	private static PlayerManager instance;

	public int lives = 3;
	private float maxStamina = 2;

	public GameObject wonImage;
	public GameObject lostImage;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		} else if (instance != this)
		{
			Destroy(this.gameObject);
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
		lostImage.SetActive(true);
		StartCoroutine(RestartGame());
		//Destroy(GameObject.FindGameObjectWithTag("Player"));

		//SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
		//GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Died();
	}

	public IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
		lostImage.SetActive(false);
		wonImage.SetActive(false);
		lives = 3;
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
