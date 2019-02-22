using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform enemy ;
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("LaunchProjectile", 1.0f, 0.6f);
	}

	void LaunchProjectile()
	{
		Instantiate(enemy, (transform.position), Quaternion.identity);

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
