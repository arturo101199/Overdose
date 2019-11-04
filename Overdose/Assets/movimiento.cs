﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        
    }

    // Use this for initialization
    void FixedUpdate()
    {

        float moverHorizontal = Input.GetAxis ("Horizontal");
        float moverVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moverHorizontal, moverVertical);
        rb2d.AddForce (movement*speed);

    }
}	
