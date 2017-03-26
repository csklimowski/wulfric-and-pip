﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour {
    
    // Use this for initialization
    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Pip" || other.gameObject.tag == "Wulfric"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
