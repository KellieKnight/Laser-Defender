﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        moveShip();
        
	}

    void moveShip()
    {
        

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){

            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}