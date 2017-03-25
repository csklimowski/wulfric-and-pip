using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isWulfric : MonoBehaviour {

	private Rigidbody2D body;
	private BoxCollider2D myCollider;
	public GameObject holding;
	public GameObject box, pip;

	// Use this for initialization
	void Start () {
		body = GetComponent <Rigidbody2D> ();
		myCollider = GetComponent <BoxCollider2D> ();
		holding = null;
	}

	// Update is called once per frame
	void Update () {
		if (body.velocity.y == 0 && Input.GetKeyDown(KeyCode.W)) {
			body.velocity += new Vector2(0, 5);
		}

		if (Input.GetKey(KeyCode.A)) {
			body.velocity = new Vector2(-2, body.velocity.y);
		} else if (Input.GetKey(KeyCode.D)) {
			body.velocity = new Vector2(2, body.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			if (holding == null) {
				if (myCollider.bounds.Intersects (box.GetComponent<BoxCollider2D> ().bounds)) {
					holding = box;
				} else if (myCollider.bounds.Intersects (pip.GetComponent<BoxCollider2D> ().bounds)) {
					holding = pip;
				}
			} else {
				if (Input.GetKey (KeyCode.A)) {
					holding.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-10, 4);
				} else if (Input.GetKey (KeyCode.D)) {
					holding.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 4);
				} else {
					holding.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 10);
				}
				holding = null;
			}
		}

		if (holding != null) {
			holding.transform.position = transform.position;
			//holding.transform.position += new Vector3 (0.9 * (transform.position.x - holding.transform.position.x) * Time.deltaTime, 0.9 * (transform.position.y - holding.transform.position.y) * Time.deltaTime, 0);
		}
	}
}
