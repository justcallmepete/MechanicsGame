﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothSpeed = .124f;
	public Vector3 offset;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void FixedUpdate()
	{
		if (!target) return;

		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}