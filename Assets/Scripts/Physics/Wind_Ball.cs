using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Ball : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			// give player windball
			other.GetComponent<PlayerController>();
		}
	}
}
