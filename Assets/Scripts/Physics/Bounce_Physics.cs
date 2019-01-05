using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Physics : MonoBehaviour {


	private CircleCollider2D bouncePart;
	private float waitTime = 2f;

	private void Start()
	{
		bouncePart = GetComponent<CircleCollider2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			bouncePart.enabled = false;
			StartCoroutine(BouncePart());
		}
	}

	IEnumerator BouncePart()
	{
		yield return new WaitForSecondsRealtime(waitTime);
		bouncePart.enabled = true;
	}
}
