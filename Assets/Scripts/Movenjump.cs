using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movenjump : MonoBehaviour {

	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (body.velocity.y == 0 && Input.GetKeyDown (KeyCode.Space)) {
			body.velocity += new Vector2 (0, 5);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			body.velocity = new Vector2 (-2, body.velocity.y);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			body.velocity = new Vector2 (2, body.velocity.y);
		}
	}
}
