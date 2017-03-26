using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPip : MonoBehaviour {

    private Rigidbody2D body;
	private Animator animator;
    public BoxCollider2D myCollider;
	public SwitchScript lever;
    public Enemy enemy;
	public isWulfric wulfric;
    private bool enemyKnockedOut;

    // Use this for initialization
    void Start()
    {
		animator = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
		animator.Play ("Idle");
    }

	bool IsCurrentAnim(string str) {
		return animator.GetCurrentAnimatorStateInfo (0).IsName (str);
	}

    // Update is called once per frame
    void Update () {
		print (body.velocity.y);
		
        transform.gameObject.tag = "Pip";
        if (body.velocity.y == 0 && Input.GetButtonDown("Pip Jump"))
        {
			animator.Play ("Rising");
            body.velocity += new Vector2(0, 5);
        }

		if (IsCurrentAnim ("Rising") && body.velocity.y < 0) {
			animator.Play ("Transition");
		} else if (IsCurrentAnim ("Transition") && body.velocity.y == 0) {
			animator.Play ("Landing");
		}

		if (Input.GetAxis ("Pip Move") == -1) {
			body.velocity = new Vector2 (-2, body.velocity.y);
			if (IsCurrentAnim ("Idle")) {
				animator.Play ("Run");
			}
			transform.localScale = new Vector2 (-3, transform.localScale.y);
		} else if (Input.GetAxis ("Pip Move") == 1) {
			body.velocity = new Vector2 (2, body.velocity.y);
			if (IsCurrentAnim ("Idle")) {
				animator.Play ("Run");
			}
			transform.localScale = new Vector2 (3, transform.localScale.y);
		} else {
			if (IsCurrentAnim("Run")) {
				animator.Play ("Idle");
			}
		}

		if (Input.GetButtonDown ("Pip Switch")) {
            if (lever != null)
            {
                if (myCollider.bounds.Intersects(lever.GetComponent<BoxCollider2D>().bounds))
                {
					lever.Toggle ();
                }
            }
		}

		if (wulfric.pipHeld) {
			animator.Play ("Hanging");
		} else if (IsCurrentAnim ("Hanging")) {
			animator.Play ("Rising");
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
