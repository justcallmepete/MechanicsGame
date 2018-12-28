using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private static PlayerManager instance;

	private void Awake()
	{
		instance = this;
	}

	public static PlayerManager Instance
	{
		get
		{
			if (!instance)
			{
				instance = new PlayerManager();
				DontDestroyOnLoad(instance);
			}

			return instance;
		}
	}
	// player stats somewhere

	// playerspawner

	// keep track of checkPoints
	public Vector2 lastCheckPointPos;

}
