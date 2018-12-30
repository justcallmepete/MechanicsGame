using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

	[SerializeField]
	private GameObject canvas;
	[SerializeField]
	private Text text;

	public string tip;

	private void OnValidate()
	{
		text.text = tip;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			canvas.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			canvas.SetActive(false);
		}

	}
}
