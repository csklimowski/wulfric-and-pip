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
			animator.SetBool ("Up", false);
			door.open = false;
		} else {
			animator.SetBool ("Up", true);
			door.open = true;
		}
	}
}
