﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D body;
    private BoxCollider2D collision;
    public GameObject bullet;
    private bool knockedOut = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(fireBullet());
	}
	
	IEnumerator fireBullet () {
        while (true)
        {
            if (knockedOut == false)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            if(knockedOut == true)
            {
                StartCoroutine(wakeUp());
                knockedOut = false;
                yield return new WaitForSeconds(0);
            }
            yield return new WaitForSeconds(3);
        }
	}

    IEnumerator wakeUp()
    {
        yield return new WaitForSeconds(10);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box")
        {
            knockedOut = true;
        }
        if (col.gameObject.tag == "Pip" && Input.GetKey(KeyCode.Space) && knockedOut == true)
        {
            DestroyObject(gameObject);
        }
    }
}
