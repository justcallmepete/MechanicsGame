using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed = .2f;
	public Transform leftEdge;
	public Transform rightEdge;
	public GameObject platform;
	public bool movingRight = true;

	private void Update()
	{
		if (movingRight)
		{
			platform.transform.Translate(Vector3.right * speed * Time.deltaTime);
		} else
		{
			platform.transform.Translate(Vector3.right * -speed * Time.deltaTime);
		}

		if (platform.transform.position.x >= rightEdge.position.x && movingRight)
		{
			movingRight = false;
		}

		if(platform.transform.position.x <= leftEdge.position.x && !movingRight)
		{
			movingRight = true;
		}
	}
}
