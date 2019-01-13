using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Orb : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerController controller = collision.GetComponent<PlayerController>();
			if (controller.maxStamina < 1)
			{
				controller.maxStamina += .25f;
			} else if (controller.maxStamina > 1)
			{
				controller.maxStamina = 1;
			}
			Destroy(gameObject);
		}
	}
}
