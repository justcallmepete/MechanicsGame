﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothSpeed = .124f;
	public Vector3 offset;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}