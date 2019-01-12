using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Ball : MonoBehaviour {

	Inventory inventory;
	public GameObject itemButton;


	private void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			for (int i = 0; i < inventory.slots.Length; i++)
			{
				if (inventory.isTaken[i] == false)
				{
					//add item

					inventory.isTaken[i] = true;
					Instantiate(itemButton, inventory.slots[i].transform, false);
					Destroy(gameObject);
					break;
				}
			}
		}
	}
}
