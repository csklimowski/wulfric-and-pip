using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public bool open;
	public float closedX;
	public float closedY;
	public float openX;
	public float openY;
	public float speed;

	void Create() {
	}

	void Update () {
		if (open) {
			GetComponent<Rigidbody2D>().MovePosition(Vector3.MoveTowards (transform.position, new Vector3 (openX, openY), speed));
		} else {
			GetComponent<Rigidbody2D>().MovePosition(Vector3.MoveTowards (transform.position, new Vector3 (closedX, closedY), speed));
		}
	}
}
