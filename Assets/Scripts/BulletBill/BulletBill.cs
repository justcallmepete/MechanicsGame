using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBill : MonoBehaviour {



	private void Update()
	{
		transform.position -= new Vector3(2,0,0) * Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{ 

		if (collision.transform.tag == "Player")
		{
			// kill player
			Debug.Log("Player hit");
			//instantiate explosion?

			//Destroy self
			Destroy(this.gameObject);
		}

		if (collision.transform.tag == "Cleaner")
		{
			Debug.Log("Cleaner Hit");
			Destroy(this.gameObject);
		}
	}
}
