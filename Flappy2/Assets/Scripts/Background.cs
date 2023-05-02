using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    private BoxCollider2D bgCollider;
    private float bgLength;
    // Use this for initialization
    void Start() {

        bgCollider = GetComponent<BoxCollider2D>();
        bgLength = bgCollider.size.x;

	}
	
	// Update is called once per frame
	void Update () {
        
        //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        if (transform.position.x < -bgLength)
        {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            repositionBackground();
        }
    }

    void repositionBackground()
    {

        Vector2 offset = new Vector2(bgLength*2f, 0);
        transform.position = (Vector2) transform.position + offset;

    }

}
