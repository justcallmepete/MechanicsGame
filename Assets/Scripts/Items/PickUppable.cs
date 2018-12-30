using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickUppable : MonoBehaviour {

	[SerializeField]
	private Item item;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			var pc = other.GetComponent<Inventory>();
			if (item.sort == ItemSort.Instant)
			{
				pc.OnItemPickup(item);
				Destroy(this.gameObject);
			}
			if (item.sort == ItemSort.Use)
			{
				pc.OnItemGain(item);
			}
			// give player a key
			// destroy yourself
			
		}
	}
}
