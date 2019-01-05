using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpike : MonoBehaviour {


	public List<GameObject> spikes = new List<GameObject>();

	public Transform center;
	public float speed = 10;
	//platform to rotate around center object or position?

	private Vector3 zAxis = new Vector3(0, 0, 1);

	private void Update()
	{
		foreach(GameObject spike in spikes)
		{
			spike.transform.RotateAround(center.position, zAxis, speed * Time.deltaTime);
		}
	}

}
