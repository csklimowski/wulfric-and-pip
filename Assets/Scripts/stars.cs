using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stars : MonoBehaviour {
	public float targetTime = 4f;
	public float speed = 5f;
	private bool upperino = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		targetTime -= Time.deltaTime;
		if (targetTime <= 0) {
			upperino = true;
			targetTime = 4f;
		}
		if (upperino == true) {
			transform.Translate (2,0,0);
			upperino = false;
		}
		transform.Translate (Vector2.left * speed * Time.deltaTime, 0);

	}
}
