using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Implemented by: Rishav, Douglas, and Carlos */

public class Bird : MonoBehaviour {

	public float upForce = 200f;

	private bool isDead = false;
	private bool grounded= true;
    private bool falling = true;
	private bool debug = false;						//Added this so I don't have to hold down spacebar when debugging
	static public bool birdDiedCorrectly = true;	// used for unit test

	private Rigidbody2D rb2d;
	private Animator anim;

    private float birdInitPos;
    private float jumpStart;                    //holds the bird's y-axis position at the start of a jump
    private float newForce;						//the bird's upwards thrust as it jumps.
	//public float height = 5f;					//used in CalculateJumpHeight()
	//note: moved birdDiedCorrectly to be w/ other bools.

    private Vector2 saveBirdState;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
        
		grounded = true;                     // enable jumping

		birdInitPos = rb2d.position.x;
	}
	
	// Update is called once per frame
	void Update () {

			
	}// End Update()

	void FixedUpdate(){

		//sets falling to true while the bird is falling
		if (rb2d.velocity.y < 0)
			falling = true;

		// kill player if too low
		if (rb2d.position.y < -7.5) {
			die();
		}
		// jump when mouse clicked
		if (isDead == false) {/*
                if (Input.GetKey("space") && canJump){       // Can use to replace mouse jump with space. Carlos Recommends!
                //if (Input.GetMouseButtonDown(0) && canJump) {
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flap");
				canJump = false;	// disable jumping
                */
			if (grounded && falling)	//This fixes a bug where you can't jump at the platform's end.
				falling = false;
			
			if ((Input.GetKey("space") || debug) && !falling) {	
				if (grounded) {
					jumpStart = rb2d.position.y;
					rb2d.velocity = Vector2.zero;
					//rb2d.velocity = new Vector2(rb2d.velocity.x, (upForce));
					rb2d.AddForce (new Vector2 (0, upForce));
					newForce = upForce;
					anim.SetTrigger("Flap");
					grounded = false;// disable jumping
					falling = false;

				}

				//There's a weird glitch here causing jump heights to vary. Adding 500 to the calculations below didn't help.
				//Gonna check this code; maybe it'll fix it: https://forum.unity.com/threads/mario-style-jumping.381906/
				if (rb2d.position.y < jumpStart + 4) {
					rb2d.velocity = new Vector2(rb2d.velocity.x, newForce);
					newForce *= .98f;	//The force added onto the bird diminishes the longer the button is held.

					//if (rb2d.position.y - jumpStart >= 1f)				
					//	newForce *= 1/(rb2d.position.y - jumpStart);
				} 
				else {
					falling = true;
					//rb2d.velocity = new Vector2 (rb2d.velocity.x, 3f);		//Ensures bird can't jump higher than 4 spaces above jump start position
				}

			}//end if for jumpin
		}//end if for isDead == false

		if (rb2d.position.x < birdInitPos)
			rb2d.velocity = new Vector2(1, rb2d.velocity.y);
		else
			rb2d.velocity = new Vector2(0, rb2d.velocity.y);

		// TESTER Section - Tested by BirdTests
		if (rb2d.position.y < -7.5 && isDead == true) {
			birdDiedCorrectly = false;
		}
		
	}//End FixedUpdate()



	void OnCollisionEnter2D () {
		rb2d.velocity = Vector2.zero;
		grounded = true;	// enable jumping
        falling = false;// reset falling ability.
		/*
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
		*/
	}

    public void pauseGame()
    {

        saveBirdState = rb2d.velocity;

        rb2d.velocity = Vector2.zero;

    }

    public void resumeGame()
    {
		rb2d.velocity = saveBirdState; 
	}

	void die(){
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
	/*
	float CalculateJumpForce(float gravityMagnitude, float height)
	{
		//h = v^2/2g
		//2gh = v^2
		//sqrt(2gh) = v
		return Mathf.Sqrt (2 * gravityMagnitude * height);
	}
*/
}

