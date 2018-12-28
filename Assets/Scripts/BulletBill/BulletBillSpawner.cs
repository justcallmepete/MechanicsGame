using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBillSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private float timeBetweenBullets = 2f;

	private void Start()
	{
		
	}

	IEnumerator ShootPrefab()
	{
		GameObject Bill = Instantiate(prefab);
		yield return new WaitForSeconds(timeBetweenBullets);
		StartCoroutine(ShootPrefab());
	}
}
