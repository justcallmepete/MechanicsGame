using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Physics : MonoBehaviour {

	// player movement input is cancelled
	// player movement stays the same
	// flipping is possible

	private bool onIce = false;
	private Rigidbody2D rb;
	private Vector2 velocity;

	private void FixedUpdate()
	{
		if (onIce)
		{
			if (rb)
			{
				//rb.AddForce();
			}
		}	
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			onIce = true;
			rb = collision.GetComponent<Rigidbody2D>();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			onIce = false;
			rb = null;
		}
	}
}
