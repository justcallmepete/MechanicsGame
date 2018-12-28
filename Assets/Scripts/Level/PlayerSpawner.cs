using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject prefab;

	public void SpawnPlayer()
	{
		Instantiate(prefab);
	}
}
