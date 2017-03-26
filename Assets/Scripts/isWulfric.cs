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

	bool IsCurrentAnim(string str) {
		return animator.GetCurrentAnimatorStateInfo (0).IsName (str);
	}

	// Update is called once per frame
	void Update () {
		if (body.velocity.y == 0 && Input.GetButtonDown("Wulfric Jump")) {
			body.velocity += new Vector2(0, 5);
			animator.Play ("Rising");
		}

		if (IsCurrentAnim ("Rising") && body.velocity.y < 0) {
			animator.Play ("Transition");
		} else if (IsCurrentAnim ("Transition") && body.velocity.y == 0) {
			animator.Play ("Land");
		}

		if (Input.GetAxis ("Wulfric Move") == -1) {
			if (IsCurrentAnim("Idle")) {
				animator.Play ("Walk");
			}
			body.velocity = new Vector2 (-2, body.velocity.y);
			transform.localScale = new Vector2 (3, transform.localScale.y);
		} else if (Input.GetAxis ("Wulfric Move") == 1) {
			if (IsCurrentAnim("Idle")) {
				animator.Play ("Walk");
			}
			body.velocity = new Vector2 (2, body.velocity.y);
			transform.localScale = new Vector2 (-3, transform.localScale.y);
		} else {
			if (IsCurrentAnim("Walk")) {
				animator.Play ("Idle");
			}
		}

		if (Input.GetButtonDown("Wulfric Throw")) {
			if (holding == null) {
				if (body.velocity.y == 0) {
					animator.Play ("Pick Up");
				}
				if (myCollider.bounds.Intersects (box.GetComponent<BoxCollider2D> ().bounds)) {
					holding = box;
				} else if (myCollider.bounds.Intersects (pip.GetComponent<BoxCollider2D> ().bounds)) {
					holding = pip;
				}
			} else {
				if (Input.GetAxis("Wulfric Move") == -1) {
					animator.Play ("Throw Side");
					StartCoroutine (throwHeld (-10, 4));
				} else if (Input.GetAxis("Wulfric Move") == 1) {
					animator.Play ("Throw Side");
					StartCoroutine (throwHeld (10, 4));
				} else {
					animator.Play ("Throw");
					StartCoroutine (throwHeld (0, 10));
				}
			}
		}

		if (Input.GetButtonDown ("Wulfric Switch")) {
			if (myCollider.bounds.Intersects (lever.GetComponent<BoxCollider2D> ().bounds)) {
				lever.Toggle ();
			}
		}

		if (holding != null) {
			holding.GetComponent<Rigidbody2D>().MovePosition(Vector3.MoveTowards (holding.transform.position, new Vector3(transform.position.x, transform.position.y - 0.6f), 0.1f));
		}
	}

	IEnumerator throwHeld(float x, float y) {
		yield return new WaitForSeconds(1);
		print ("test");
		holding.GetComponent<Rigidbody2D> ().velocity = new Vector2 (x, y);
		holding = null;
	}
}
