using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Battle : MonoBehaviour {

	bool battleStarted = false;

	public float hp = 50;

	private void Update()
	{
		if (!battleStarted) return;
		

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Weapon")){
			hp -= 25;
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerController>().TakeDamage(1);
		}
	}

}
