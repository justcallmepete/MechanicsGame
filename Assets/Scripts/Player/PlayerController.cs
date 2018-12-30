using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private PlayerManager playerManager;

	public CharacterController2D controller;
	private Rigidbody2D rb2d;

	public int hp = 1;

	public float movementSpeed = 40f;
	float horizontalMove = 0;
	bool isJumping = false;
	bool isCrouching = false;


	//Wind physics
	private bool inWindzone = false;
	private Wind_Physics windZone;

	private void Awake()
	{
		playerManager = PlayerManager.Instance;
		
	}

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
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

		// WindZone
		if (inWindzone)
		{
			rb2d.AddForce(windZone.direction * windZone.strength);
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("WindZone"))
		{
			windZone = other.gameObject.GetComponent<Wind_Physics>();
			inWindzone = true;
			Debug.Log("In Windzone");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("WindZone"))
		{
			windZone = null;
			inWindzone = false;
		}
	}
}
