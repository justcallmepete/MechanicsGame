using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	bool inCollisionZone = false;

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
		if (Input.GetKeyDown(KeyCode.E))
		{
			Debug.Log("Key needed");
		}
	}
}
