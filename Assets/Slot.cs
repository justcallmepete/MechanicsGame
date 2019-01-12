using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	Inventory inventory;
	public int id = 0;

	private void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	private void Update()
	{
		if (transform.childCount <= 0)
		{
			inventory.isTaken[id] = false;
		}
	}

	public void UseItem()
	{

	}
}
