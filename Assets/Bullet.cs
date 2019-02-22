using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject enemyTarget;
	public float velocity = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = enemyTarget.transform.position;
		Vector3 targetDir = (targetPos - transform.position).normalized;
		transform.Translate(targetDir * Time.deltaTime * velocity);
	}
}
