using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObstacle : MonoBehaviour {

	public GameObject[] obstacles;
	public Vector3[] positions;

	private void Start()
	{
		for (int i =0; i< obstacles.Length; i++)
		{
			positions[i] = obstacles[i].transform.position;
		}
	}

	public void Reset()
	{
		for(int i = 0; i < obstacles.Length; i++)
		{
			if (obstacles[i].GetComponent<Rigidbody2D>())
			{
				Rigidbody2D obsRB = obstacles[i].GetComponent<Rigidbody2D>();
				obsRB.constraints = RigidbodyConstraints2D.FreezeAll;
				obstacles[i].GetComponent<FallingBlock>().playerOnBlock = false;
				obstacles[i].GetComponent<FallingBlock>().timer = 0;
			}
			obstacles[i].transform.position = positions[i];
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Reset();
		}
	}
}
