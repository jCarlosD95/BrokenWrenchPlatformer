using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Implemented by: Rishav, Douglas, and Carlos */

public class plankPool : MonoBehaviour {

	public int plankPoolSize = 5;
	public GameObject plankPrefab;
	public float spawnRate = 6f;
	public float plankYMin = -6f;
	public float plankYMax = -3f;

	private GameObject[] planks;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private float timeSinceLastSpawned;
	private float spawnXPosition = 20f;     //Edited by Carlos so planks don't appear out of thin air onscreen
	private int currentPlank = 0;

	static public bool plankIsInRange = true;
	//private bool runInTestMode = false;

	/*
	// TESTING constructor to set 
	public void Construct(Object testerPlankPrefab) {
		plankPrefab = (GameObject) testerPlankPrefab;
	}
	*/

	// Use this for initialization
	void Start () {
		planks = new GameObject[plankPoolSize];
		for (int i = 0; i < plankPoolSize; i++) {
			planks [i] = (GameObject)Instantiate (plankPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
		
	// Update is called once per frame
	void Update () {
		plankIsInRange = true;
		timeSinceLastSpawned += Time.deltaTime;
		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (plankYMin, plankYMax);
			planks [currentPlank].transform.position = new Vector2 (spawnXPosition, spawnYPosition);

			// TEST SECTION - flag if plank is out of range --->
			if (spawnYPosition < plankYMin || spawnYPosition > plankYMax) {
				plankIsInRange = false;	// ERROR: plank has been placed OUT OF RANGE
			}
			// END OF TEST SECTION <--------------------------//

			currentPlank++;
			if (currentPlank >= plankPoolSize) {
				currentPlank = 0;
			}
		}
	}
}
