using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellInHole : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("fell in hole");
			collision.GetComponent<PlayerController>().FellDown();
		}
	}
}
