using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {

        
        /*Loop over every child object
         grab their transform
         spawn an enemy on top of every position*/
        foreach(Transform child in transform)
        {
            //Instantiate enemies in the same place of their parent object (position)
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

            //Instantiate enemy inside a position (child)
            enemy.transform.parent = child;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
