﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetTrigger("Run");

    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.position.y < -7.5)
        {
            rb2d.velocity = Vector2.zero;
            isDead = true;
            //anim.SetTrigger("Die");
            //GameControl.instance.BirdDied();
        }
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                //anim.SetTrigger("Jump");
            }
        }

    }



    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        /*
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
		*/
    }
}
