using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour {

	private PlayerManager playerManager;

	private void Start()
	{
		playerManager = PlayerManager.Instance;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerManager.lastCheckPointPos = this.transform.position;
		}
	}
}
