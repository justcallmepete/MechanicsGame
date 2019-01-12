using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	bool inCollisionZone = false;
	public int sceneToLoad;

	GameObject player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			inCollisionZone = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			inCollisionZone = false;
		}
	}

	private void Update()
	{
		//if (!inCollisionZone) return;

		if (Input.GetKeyDown(KeyCode.E))
		{
			PlayerManager.Instance.LoadNextLevel(sceneToLoad);
			DontDestroyOnLoad(player);
		}
	}
}
