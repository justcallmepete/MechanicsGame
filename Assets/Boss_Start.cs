using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Start : MonoBehaviour {


	public Boss_Battle boss;
	// Use this for initialization


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			boss.battleStarted = true;
			Destroy(gameObject);
		}
	}
}
