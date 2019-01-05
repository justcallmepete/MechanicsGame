﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {
	PlatformEffector2D effector;
	public float waitTime;

	// Use this for initialization
	void Start () {
		effector = GetComponent<PlatformEffector2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			waitTime = .5f;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			if(waitTime <= 0)
			{
				effector.rotationalOffset = 180f;
				waitTime = .5f;
			} else
			{
				waitTime -= Time.deltaTime;
			}
		}

		if (Input.GetKey(KeyCode.UpArrow)){
			effector.rotationalOffset = 0;
		}
	}
}
