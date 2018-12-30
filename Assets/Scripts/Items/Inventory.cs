using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	[SerializeField]
	private PlayerController playerController;
	[SerializeField]
	private Transform inventoryTrans;

	public List<Item> itemsInInventory = new List<Item>();

	public void OnItemPickup(Item item)
	{
		item.OnPickUp(playerController);
	}

	public void OnItemGain(Item item)
	{
		Destroy(item.gameObject.GetComponent<PickUppable>());
		item.transform.SetParent(inventoryTrans);	
		item.gameObject.SetActive(false);
	}
}
