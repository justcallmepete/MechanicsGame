using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemSort
{
	Instant,
	Use
}

public class Item : MonoBehaviour
{
	public ItemSort sort;
	// does the item do something when it is picked up?
	public virtual void OnPickUp(PlayerController controller) { }
	public virtual void UseItem(PlayerController controller) { }


}
