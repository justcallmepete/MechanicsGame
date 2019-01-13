using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Battle : MonoBehaviour {

	public bool battleStarted = false;
	GameObject player;
	public Slider healthBar;
	public Image YouWon;
	bool won = false;
	public float speed = 5;
	bool restart = false;

	public float hp = 50;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		if (!battleStarted) return;

		healthBar.value = hp;
		if (hp <= 0)
		{
			if (Input.GetKeyDown(KeyCode.E) && !restart)
			{
				Destroy(GameObject.FindGameObjectWithTag("Player"));
				StartCoroutine(PlayerManager.Instance.RestartGame());
				restart = true;
			}

			if (!won)
			StartCoroutine(BossDead());
		}
		else
		{

			Vector3 playerPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
			transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("UberSpike")){
			hp -= 10;
			Debug.Log("OUCH");
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerController>().TakeDamage(1);
		}
	}

	IEnumerator BossDead()
	{
		won = true;
		PlayerManager.Instance.wonImage.SetActive(true);
		GetComponentInChildren<Animator>().enabled = false;

		yield return 0;
	}

}
