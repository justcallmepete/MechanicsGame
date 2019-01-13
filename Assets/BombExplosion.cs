using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour {

	float timer = 0;
	public float duration = .5f;


	private void OnEnable()
	{
		
	}

	private void Update()
	{
		timer += 1 * Time.deltaTime;

		if (timer >= duration)
		{
			Destroy(gameObject);
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		// if collides with door damage da door

		// if collides with player - damage da player
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerController>().TakeDamage(1);
		}

		// if collides with enemy - kill enemy
		// if collides with player - damage da player
		if (collision.CompareTag("Enemy"))
		{
			if (collision.GetComponent<Enemy>())
			{
				collision.GetComponent<Enemy>().SpawnPrefab();
			} 
				Destroy(collision.transform.gameObject);
		}
	}
}
