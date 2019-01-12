using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

	public GameObject itemToSpawn;
	private int cost = 1;
	GameObject player;

	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(SpawnItem);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void SpawnItem()
	{
		if (player.GetComponent<PlayerController>().mana - cost >= 0)
		{
			Instantiate(itemToSpawn, player.transform.position, itemToSpawn.transform.rotation, null);
			player.GetComponent<PlayerController>().mana -= 1;
			Destroy(gameObject);
		}
	}
}
