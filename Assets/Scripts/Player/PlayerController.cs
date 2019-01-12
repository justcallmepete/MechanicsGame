using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private PlayerManager playerManager;
	private Rigidbody2D rb2d;
	private Vector3 m_Velocity = Vector3.zero;

	public int hp = 3;

	public int mana = 1;
	private int maxMana = 3;

	public Image hpImage;
	public List<Sprite> healthbar = new List<Sprite>();



	public float movementSpeed = 5f;
	public float crouchSpeed = 1f;
	float horizontalMove = 0;
	bool isJumping = false;
	bool isCrouching = false;
	public bool isBounced = false;

	//jumping
	float fallMultiplier = 2.5f;
	float lowJumpMultiplier = .5f;
	public Image fill;
	public Image manaFill;
	private float jumpCost = .5f;
	public float stamina = 1;
	public float maxStamina = 1;
	public bool jumpedOnce = false;


	[SerializeField]
	private LayerMask groundLayer;
	public float groundCheckRadius;
	public bool isGrounded = true;
	public Transform groundCheckPoint;

	private void Start()
	{
		playerManager = PlayerManager.Instance;
		rb2d = GetComponent<Rigidbody2D>();
		
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

		GainStamina();
		GainMana();
		hpImage.sprite = healthbar[hp];
	}

	private void FixedUpdate()
	{
		Move(horizontalMove * Time.fixedDeltaTime, isCrouching);
		Jump(isJumping);
		isGrounded = IsGrounded();
		if (isGrounded)
		{
			if (isBounced)
			{
				isBounced = false;
			}
		}
		isJumping = false;
	}

	private void Move(float move, bool crouch)
	{
		if (isBounced) return;
		//movement
		Vector3 targetVelocity = new Vector2(move * movementSpeed, rb2d.velocity.y);
		rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref m_Velocity, 0);

		if (crouch)
		{
		targetVelocity = new Vector2(move * movementSpeed, rb2d.velocity.y);
		rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref m_Velocity, 0);
		}

	}

	private void Jump(bool isJumping)
	{

		if (isJumping && isGrounded || isJumping && jumpedOnce)
		{
			isGrounded = false;
			//rb2d.velocity = Vector2.up * 3f;
			if (jumpCost <= stamina)
			{
				rb2d.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
				stamina -= jumpCost;
				if(!jumpedOnce)
				jumpedOnce = true;
			}
		}
		//jumping
		if (rb2d.velocity.y < 0)
		{
			rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}

		
	}

	private void GainStamina()
	{
		fill.fillAmount = stamina;

		if (!isGrounded) return;
		if (stamina > maxStamina)
		{
			stamina = maxStamina;
		}

		if (stamina < maxStamina)
			stamina += .3f * Time.deltaTime * 5;

	}

	private void GainMana()
	{
		if(mana == 0)
		{
			manaFill.fillAmount = 0;
		} else if (mana == 1)
		{
			manaFill.fillAmount = .33f;
		} else if (mana == 2)
		{
			manaFill.fillAmount = .66f;
		} else if (mana == 3)
		{
			manaFill.fillAmount = 1f;
		}
	}

	private bool IsGrounded()
	{

		return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
	}

	public void TakeDamage(int amount)
	{
		if ((hp - amount) <= 0)
		{
			playerManager.ResetScene();
		}
		else
		{
			hp -= amount;
		//	hpImage.sprite = healthbar[hp];
		}
		Debug.Log("Damage taken: " + amount);
	}

	public void GainHealth(int amount)
	{
		if (hp + amount <= 3)
		{
			hp -= amount;
			hpImage.sprite = healthbar[hp];
		}
	}

	public IEnumerator Knockback(float duration, float power, Vector3 direction)
	{
		float timer = 0;
		while (timer < duration)
		{
			timer += Time.deltaTime;
			rb2d.AddForce(new Vector3(direction.x - 100, direction.y + power, transform.position.z));
		}

		yield return 0;
	}

	public void FellDown()
	{
		hp -= 1;
		if (hp <= 0)
		{
			playerManager.ResetScene();

		} else
		{
			hpImage.sprite = healthbar[hp];
			transform.position = playerManager.lastCheckPointPos.position;
		}
		
	}

	public void Died()
	{
		hp = 3;
		hpImage.sprite = healthbar[3];
		transform.position = playerManager.lastCheckPointPos.position;
	}
}
