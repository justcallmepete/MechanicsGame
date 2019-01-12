using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	Inventory inventory;
	public int id = 0;
	public KeyCode key;

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

		if (transform.childCount > 0)
		{
			if (Input.GetKeyDown(key))
			{
				Debug.Log("item used");
				transform.GetChild(0).GetComponent<Button>().onClick.Invoke();
			}
		}
	}

	public void UseItem()
	{

	}
}
