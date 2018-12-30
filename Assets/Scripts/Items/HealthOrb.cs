using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : Item {

	public override void OnPickUp(PlayerController controller)
	{
		controller.hp += 1;
	}


}
