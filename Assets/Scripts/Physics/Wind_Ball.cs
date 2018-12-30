using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Ball : MonoBehaviour {

	private bool inWindzone = false;
	private Wind_Physics zone;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (inWindzone)
		{
			Debug.Log("In windzone");
			rb.AddForce(zone.direction * zone.strength);	
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("WindZone"))
		{
			zone = other.GetComponent<Wind_Physics>();
			inWindzone = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		zone = null;
		inWindzone = false;
	}
}
