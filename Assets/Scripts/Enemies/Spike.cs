using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
	public int damage = 1;

	CircleCollider2D col1;
	BoxCollider2D col2;

	private void Start()
	{
		col1 = GetComponent<CircleCollider2D>();
		col2 = GetComponent<BoxCollider2D>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (other.transform.GetComponent<PlayerController>())
			{
				other.transform.GetComponent<PlayerController>().TakeDamage(damage);
				col2.enabled = true;
			}
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			col1.enabled = false;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			col2.enabled = false;
			col1.enabled = true;
		}
	}
}