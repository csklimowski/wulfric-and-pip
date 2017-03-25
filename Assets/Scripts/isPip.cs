using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPip : MonoBehaviour {

    private Rigidbody2D body;
    private BoxCollider2D myCollider;
	public SwitchScript lever;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        transform.gameObject.tag = "Pip";
        if (body.velocity.y == 0 && Input.GetButtonDown("Pip Jump"))
        {
            body.velocity += new Vector2(0, 5);
        }

        if (Input.GetAxis("Pip Move") == -1)
        {
            body.velocity = new Vector2(-2, body.velocity.y);
        }
        else if (Input.GetAxis("Pip Move") == 1)
        {
            body.velocity = new Vector2(2, body.velocity.y);
        }

        if (Input.GetButtonDown("Pip Stab"))
        {
            transform.gameObject.tag = "kill";
        }

		if (Input.GetButtonDown ("Pip Switch")) {
			if (myCollider.bounds.Intersects (lever.GetComponent<BoxCollider2D> ().bounds)) {
				lever.door.open = !lever.door.open;
			}
		}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "water")
        {
            body.velocity += new Vector2(0, 5);
            body.gravityScale = -1;
        }
        if(col.gameObject.tag == "fan")
        {
            body.velocity += new Vector2(0, 10);
            body.gravityScale = -1;
        }
        if(col.gameObject.tag == "Bullet")
        {
            DestroyObject(gameObject);
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        body.gravityScale = 1;
    }

}
