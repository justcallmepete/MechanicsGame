using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {

	int hp = 2;
	public Sprite damagedWall;

	private bool entered = false;
	private bool hitOnce = false;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			entered = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			entered = hitOnce = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			if (entered && !hitOnce)
			{
				TakeDamage();
			}
		}
	}

	private void TakeDamage()
	{
		hp -= 1;
		hitOnce = true;
		if (hp <= 0)
		{
			Destroy(this.gameObject);
		} else
		{
			GetComponent<SpriteRenderer>().sprite = damagedWall;
		}
	}


}
