using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_Ball : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerController controller = collision.GetComponent<PlayerController>();
			if (controller.mana < 3)
			{
				controller.mana += 1;
				Destroy(gameObject);
			}
			
		}
	}
}
