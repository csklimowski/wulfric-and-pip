﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPip : MonoBehaviour {

    private Rigidbody2D body;
    private BoxCollider2D myCollider;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        if (body.velocity.y == 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.velocity += new Vector2(0, 5);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(-2, body.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(2, body.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "water")
        {
            body.velocity += new Vector2(0, 5);
        }
    }

}