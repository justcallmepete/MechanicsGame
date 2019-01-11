using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Physics : MonoBehaviour {

	public float strength;
	public Vector2 direction;

	private bool inWindzone = false;
	private Rigidbody2D rb;

	private void Start()
	{
		direction = this.transform.up;
	}


	void OnDrawGizmos()
	{
		Color color;
		color = Color.green;
		// local up
		DrawHelperAtCenter(this.transform.up, color, 2f);

		color.g -= 0.5f;
		// global up
		DrawHelperAtCenter(Vector3.up, color, 1f);

		color = Color.blue;
		// local forward
		DrawHelperAtCenter(this.transform.forward, color, 2f);

		color.b -= 0.5f;
		// global forward
		DrawHelperAtCenter(Vector3.forward, color, 1f);

		color = Color.red;
		// local right
		DrawHelperAtCenter(this.transform.right, color, 2f);

		color.r -= 0.5f;
		// global right
		DrawHelperAtCenter(Vector3.right, color, 1f);
	}

	private void DrawHelperAtCenter(
					   Vector3 direction, Color color, float scale)
	{
		Gizmos.color = color;
		Vector3 destination = transform.position + direction * scale;
		Gizmos.DrawLine(transform.position, destination);
	}

	private void FixedUpdate()
	{
		if (inWindzone)
		{
			Debug.Log("In windzone");
			rb.AddForce(direction * strength);
		}

	}
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				inWindzone = true;
				rb = other.GetComponent<Rigidbody2D>();
			}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			inWindzone = false;
		}
}
