using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour {

	PlayerManager playerManager;

	public List<Transform> checkpoints = new List<Transform>();


	private void Start()
	{
		playerManager = PlayerManager.Instance;
		playerManager.lastCheckPointPos = checkpoints[0];
		playerManager.SetPlayerToCheckpoint();
	}


}
