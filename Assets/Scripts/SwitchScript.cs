using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	public DoorScript door;
	private Animator animator;
	private AudioSource myAudio;
	public AudioClip doorClip, switchClip;

	void Start() {
		animator = GetComponent<Animator> ();
		myAudio = GetComponent<AudioSource> ();
	}

	public void Toggle() {
		if (door.open) {
			animator.Play ("Lever to Up");
			door.open = false;
		} else {
			animator.Play ("Lever to Down");
			door.open = true;
		}
		myAudio.PlayOneShot (switchClip);
		myAudio.PlayOneShot (doorClip);
	}
}
