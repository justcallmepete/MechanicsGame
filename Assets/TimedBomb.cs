using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedBomb : MonoBehaviour
{

	float timer = 0;
	public float duration = 10;

	public Image fill;

	[SerializeField]
	bool pickedUp = false;
	bool inZone = false;

	public GameObject Explosion;

	private Transform player;

	private void Update()
	{
		if (inZone)
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				if (!pickedUp)
				{
					transform.SetParent(player);
					//transform.position = new Vector3(0, .01f, 0);
					pickedUp = true;
				}
				return;
			}
		}
		if (pickedUp)
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				transform.SetParent(null);
			}
		}

			if (!pickedUp) return;

		timer += 1 * Time.deltaTime;
		fill.fillAmount = 1 * (timer / duration);

		if (timer >= duration)
		{
			Explode();
		}

	}

	public void Explode()
	{
		transform.SetParent(null);
		Instantiate(Explosion, transform.position, Explosion.transform.rotation, null);
		Destroy(gameObject);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			player = collision.transform;
			inZone = true;

		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			inZone = false;
		}
	}
}
