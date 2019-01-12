using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FragileEnemy : MonoBehaviour
{

	public float speed;

	bool damageDealt = false;
	float timer = 0;
	float delay = 2f;

	public GameObject deathItemSpawn;

	bool movingRight = true;
	public LayerMask groundLayer;

	public Transform groundCheck;
	SpriteRenderer spriteRenderer;

	public UnityEvent OnDeath;

	private void Awake()
	{
		if (OnDeath == null)
			OnDeath = new UnityEvent();
	}

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);

		RaycastHit2D rayDown = Physics2D.Raycast(groundCheck.position, Vector2.down, 5f, groundLayer);
		Debug.DrawRay(groundCheck.position, Vector2.down);
		if (!rayDown.collider)
		{
			if (movingRight)
			{
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = !movingRight;
			}
			else
			{
				transform.eulerAngles = new Vector3(0, -0, 0);
				movingRight = !movingRight;
			}
		}

		if (damageDealt)
		{
			timer += 1 * Time.deltaTime;

			if (timer >= delay)
			{
				damageDealt = false;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			if (!damageDealt)
			{
				collision.transform.GetComponent<PlayerController>().TakeDamage(1);
				damageDealt = true;
				timer = 0;
			}
			return;
		}

		if (movingRight)
		{
			transform.eulerAngles = new Vector3(0, -180, 0);
			movingRight = !movingRight;
		}
		else
		{
			transform.eulerAngles = new Vector3(0, -0, 0);
			movingRight = !movingRight;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			OnDeath.Invoke();
			Destroy(gameObject);
		}
	}

	public void SpawnPrefab()
	{
		if (deathItemSpawn)
		{
			Instantiate(deathItemSpawn, transform.position, deathItemSpawn.transform.rotation, null);
		}
	}
}
