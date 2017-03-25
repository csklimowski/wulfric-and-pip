using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D body;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(fireBullet());
	}
	
	// Update is called once per frame
	IEnumerator fireBullet () {
		while(true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
	}
}
