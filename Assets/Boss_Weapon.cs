using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Boss"))
		{
			Debug.Log("Oof");
			collision.GetComponent<Boss_Battle>().hp -= 10;
			Destroy(gameObject);
		}
	}
}
