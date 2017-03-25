using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private bool pressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if((col.gameObject.tag == "Wulfric" || col.gameObject.tag == "Pip") && pressed == false)
        {
            pressed = true;
        }
        if((col.gameObject.tag == "Wulfric" || col.gameObject.tag == "Pip") && pressed == true)
        {
            pressed = false;
        }
    }
}
