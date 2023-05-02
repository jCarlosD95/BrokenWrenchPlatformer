using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private GameObject[] pauseObjects;
    private bool isPaused;

    public GameObject aBird;
    public GameObject[] planks;
    public GameObject[] backgrounds;

    // Use this for initialization
    void Start () {
        isPaused = false;
        
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");

        planks = GameObject.FindGameObjectsWithTag("Plank");
        backgrounds = GameObject.FindGameObjectsWithTag("background");
        aBird = GameObject.FindGameObjectWithTag("Player");

        hidePaused();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void pauseControl()
    {
        if (isPaused == false)
        {
            isPaused = true;
            

            foreach(GameObject g in planks)
            {

                ScrollingObject otherPlanks = (ScrollingObject) g.GetComponent(typeof(ScrollingObject));
                otherPlanks.pauseGame();

            }

            foreach (GameObject g in backgrounds)
            {

                ScrollingObject otherBacks = (ScrollingObject)g.GetComponent(typeof(ScrollingObject));
                otherBacks.pauseGame();

            }

            Bird other = (Bird) aBird.GetComponent(typeof(Bird));
            other.pauseGame();

            showPaused();

        }
        else if (isPaused == true)
        {

            isPaused = false;
            
            foreach (GameObject g in planks)
            {

                ScrollingObject otherPlanks = (ScrollingObject)g.GetComponent(typeof(ScrollingObject));
                otherPlanks.resumeGame();

            }

            foreach (GameObject g in backgrounds)
            {

                ScrollingObject otherBacks = (ScrollingObject)g.GetComponent(typeof(ScrollingObject));
                otherBacks.resumeGame();

            }

            Bird other = (Bird)aBird.GetComponent(typeof(Bird));
            other.resumeGame();

            
            hidePaused();
        }
    }
    

    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}
