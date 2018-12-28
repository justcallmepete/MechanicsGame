using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {


	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other)
		{
			Debug.Log("hit");
		}
	}
}
