using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D body;
    private BoxCollider2D myCollider;
    public GameObject bullet;
    public bool knockedOut = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(fireBullet());
	}

    void Update()
    {
        
    }
	
	IEnumerator fireBullet () {
        while (true)
        {
            if (knockedOut == false)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            if(knockedOut == true)
            {
                yield return new WaitForSeconds(10);
                knockedOut = false;
            }
            yield return new WaitForSeconds(3);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box")
        {
            knockedOut = true;
        }
    }
}
