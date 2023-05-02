using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Implemented by: Douglas */

public class TokenPool : MonoBehaviour {

	public int tokenPoolSize = 5;
	public GameObject TokenPrefab;
	public float spawnRate = 6f;
	public float tokenYMin = -6f;
	public float tokenYMax = -3f;

	private GameObject[] tokens;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private float timeSinceLastSpawned;
	private float spawnXPosition = 12f;
	private int currentToken = 0;

	static public bool tokenIsInRange = true;

	// Use this for initialization
	void Start () {
		tokens = new GameObject[tokenPoolSize];
		for (int i = 0; i < tokenPoolSize; i++) {
			tokens [i] = (GameObject)Instantiate (TokenPrefab, objectPoolPosition, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		tokenIsInRange = true;
		timeSinceLastSpawned += Time.deltaTime;
		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (tokenYMin, tokenYMax);
			tokens [currentToken].transform.position = new Vector2 (spawnXPosition, spawnYPosition);

			// TEST SECTION - flag if token is out of range --->
			if (spawnYPosition < tokenYMin || spawnYPosition > tokenYMax) {
				tokenIsInRange = false;	// ERROR: token has been placed OUT OF RANGE
			}
			// END OF TEST SECTION <--------------------------//

			currentToken++;
			if (currentToken >= tokenPoolSize) {
				currentToken = 0;
			}
		}
	}
}
