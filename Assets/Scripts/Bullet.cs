using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.velocity += new Vector2(-16, 0);
    }

    void Update ()
    {

    }

	void OnBecameInvisible () {
        DestroyObject(gameObject);
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Pip" || col.gameObject.tag == "Door")
        {
            DestroyObject(gameObject);
        }
    }
}
