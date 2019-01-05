using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
	public int damage = 1;


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (other.transform.GetComponent<PlayerController>())
			{
				other.transform.GetComponent<PlayerController>().TakeDamage(damage);
			}
		}

	}
}