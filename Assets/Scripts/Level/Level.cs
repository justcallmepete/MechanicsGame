using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	Transform startCheckPoint;
	private PlayerManager playerManager;

		private void Awake()
	{
		playerManager = PlayerManager.Instance;
	}

	public void ResetLevel() {
		// lose all powerups
		// reset lives (ui)
		// reset last checkpoint
	}
}
