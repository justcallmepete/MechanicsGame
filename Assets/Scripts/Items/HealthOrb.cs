﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerController controller = collision.GetComponent<PlayerController>();
			if (controller.hp < 3)
			{
				controller.hp += 1;
				Destroy(gameObject);
			}

		}
	}


}
