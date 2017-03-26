using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isWulfric : MonoBehaviour {

	private Rigidbody2D body;
	private BoxCollider2D myCollider;
	private Animator animator;
	public GameObject holding;
	public GameObject box, pip;
	public SwitchScript lever;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		body = GetComponent <Rigidbody2D> ();
		myCollider = GetComponent <BoxCollider2D> ();
		holding = null;
	}

	// Update is called once per frame
	void Update () {
		if (body.velocity.y == 0 && Input.GetButtonDown("Wulfric Jump")) {
			body.velocity += new Vector2(0, 5);
		}

		if (Input.GetAxis ("Wulfric Move") == -1) {
			animator.SetInteger ("State", 1);
			body.velocity = new Vector2 (-2, body.velocity.y);
			transform.localScale = new Vector2 (3, transform.localScale.y);
		} else if (Input.GetAxis ("Wulfric Move") == 1) {
			animator.SetInteger ("State", 1);
			body.velocity = new Vector2 (2, body.velocity.y);
			transform.localScale = new Vector2 (-3, transform.localScale.y);
		} else {
			animator.SetInteger ("State", 0);
		}

		if (Input.GetButtonDown("Wulfric Throw")) {
			if (holding == null) {
				if (myCollider.bounds.Intersects (box.GetComponent<BoxCollider2D> ().bounds)) {
					holding = box;
				} else if (myCollider.bounds.Intersects (pip.GetComponent<BoxCollider2D> ().bounds)) {
					holding = pip;
				}
			} else {
				if (Input.GetAxis("Wulfric Move") == -1) {
					holding.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-10, 4);
				} else if (Input.GetAxis("Wulfric Move") == 1) {
					holding.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 4);
				} else {
					holding.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 10);
				}
				holding = null;
			}
		}

		if (Input.GetButtonDown ("Wulfric Switch")) {
			if (myCollider.bounds.Intersects (lever.GetComponent<BoxCollider2D> ().bounds)) {
				lever.Toggle ();
			}
		}

		if (holding != null) {
			holding.transform.position = transform.position;
			//holding.transform.position += new Vector3 (0.9 * (transform.position.x - holding.transform.position.x) * Time.deltaTime, 0.9 * (transform.position.y - holding.transform.position.y) * Time.deltaTime, 0);
		}
	}
}
