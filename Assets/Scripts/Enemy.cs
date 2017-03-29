using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D body;
    private BoxCollider2D myCollider;
    public GameObject bullet;
    public bool knockedOut = false;
	private Animator animator;
	public bool dead;
	private AudioSource myAudio;
	public AudioClip gunshot;
	private static bool stopshooting = false;
	public GameObject Pip;
	public isPip script;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
		myAudio = GetComponent<AudioSource> ();
        StartCoroutine(fireBullet());
		animator.Play ("Idle");
		myCollider = GetComponent<BoxCollider2D> ();
		dead = false;
		script = Pip.GetComponent<isPip> ();
	}

    void Update()
    {
		stopshooting = GameObject.Find("Pip").GetComponent<isPip>().dead;

		if (stopshooting == true) {
			dead = true;
		}
        
    }
	
	IEnumerator fireBullet () {
        while (true)
        {
			if (!dead) {
				if (knockedOut == false) {
					animator.Play ("Fire");
					Instantiate (bullet, new Vector3 (transform.position.x - 0.2f, transform.position.y - 0.2f), Quaternion.identity);
					myAudio.Play ();
				}
				if (knockedOut == true) {
					yield return new WaitForSeconds (4);
					animator.Play ("Get Up");
					gameObject.layer = 11;
					knockedOut = false;
				}
			}
			yield return new WaitForSeconds(3);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box")
        {
			animator.Play ("Hit");
			gameObject.layer = 10;
            knockedOut = true;
        }
    }

	public void Die() {
		animator.Play ("Death");
		StopCoroutine ("fireBullet");
		dead = true;
	}
}
