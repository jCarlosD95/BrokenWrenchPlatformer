using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public Transform firstPlank;
    public Transform player;

	public static GameControl instance;
	public GameObject gameOverText;
	public Text scoreText;
	public bool gameOver;
	public float scrollSpeed = -3f;

	private int score = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

        calcScore();
	}

    public void calcScore()
    {

        if (gameOver)
        {
            return;
        }

        score = (int)(player.position.x - firstPlank.position.x) / 10;
        scoreText.text = "Score: " + score.ToString();

    }

	public void BirdScored() {
		if (gameOver) {
			return;
		}
		//score++;
		//scoreText.text = "Score: " + score.ToString ();
	}

	public void BirdDied() {
		gameOverText.SetActive (true);
		gameOver = true;
	}


}
