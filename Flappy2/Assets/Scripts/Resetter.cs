using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/* Implemented by: Rishav, Douglas, and Carlos */

public class Resetter : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Player")
		{

			SceneManager.LoadScene("GameScene");


		}

	}
}

