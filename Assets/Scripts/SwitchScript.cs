using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	public DoorScript door;
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	public void Toggle() {
		if (door.open) {
			animator.Play ("Lever to Up");
			door.open = false;
		} else {
			animator.Play ("Lever to Down");
			door.open = true;
		}
	}
}
