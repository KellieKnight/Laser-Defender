using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed;

    private bool movingRight;
    private float xmax;
    private float xmin;

	// Use this for initialization
	void Start () {

        movingRight = false;


        //Calculate edge of screen
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = rightEdge.x;
        xmin = leftEdge.x;


        /*Loop over every child object
         grab their transform
         spawn an enemy on top of every position*/
        foreach (Transform child in transform)
        {
            //Instantiate enemies in the same place of their parent object (position)
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

            //Instantiate enemy inside a position (child)
            enemy.transform.parent = child;
        }

	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
	
	// Update is called once per frame
	void Update () {

        float formationRightEdge = transform.position.x + (width / 2);
        float formationLeftEdge = transform.position.x - (width / 2);

        if (formationRightEdge > xmax)
        {
            movingRight = false;

        }else if(formationLeftEdge < xmin)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }


	}
}
