using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;

    private float xmin;
    private float xmax;
    public float padding;

	// Use this for initialization
	void Start () {

        padding = 0.5f;

        //Distance between object and main camera
        float distance = transform.position.z - Camera.main.transform.position.z;

        //Leftmost and Rightmost position in world
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

        xmin = leftMost.x + padding ;
        xmax = rightMost.x - padding;

        //Taransforms from viewpoint space to world point space
        Camera.main.ViewportToWorldPoint(new Vector3(xmin, xmax, distance));
	}
	
	// Update is called once per frame
	void Update () {

        moveShip();
        
	}

    void moveShip()
    {
        

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){

            //Can use:
            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            //Or: Predefined unit vectors that point up, right, left, or down.
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){

            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //Restrict position to boundary of play space.
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
