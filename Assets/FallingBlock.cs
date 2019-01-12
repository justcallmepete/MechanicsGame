using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

	float timer = 0;
	float duration = 1;
	public bool playerOnBlock = false;
	Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (playerOnBlock)
		{
			timer += 1 * Time.deltaTime;
		}

		if(timer>= duration)
		{
			rb.constraints = RigidbodyConstraints2D.None;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerOnBlock = true;
		}
	}
}
