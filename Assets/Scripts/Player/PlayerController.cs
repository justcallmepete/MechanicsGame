using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private PlayerManager playerManager;

	public CharacterController2D controller;

	public float movementSpeed = 40f;
	float horizontalMove = 0;
	bool isJumping = false;
	bool isCrouching = false;

	private void Awake()
	{
		playerManager = PlayerManager.Instance;
		
	}

	private void Start()
	{
		transform.position = playerManager.lastCheckPointPos;
	}

	private void Update()
	{ 
		horizontalMove = Input.GetAxisRaw("Horizontal") *movementSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			isJumping = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			isCrouching = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			isCrouching = false;
		}
	}

	private void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
		isJumping = false;
	}
}
