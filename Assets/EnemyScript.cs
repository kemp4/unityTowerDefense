using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public GameObject[] roads;
	private int i = 0;
	// Use this for initialization
	void Start () {
		roads = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Road").OrderBy (go => go.name)).ToArray();
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetPos = roads [i].transform.position;
		Vector3 targetDir = (targetPos - transform.position).normalized;
		transform.Translate(targetDir * Time.deltaTime);
		if (Vector3.Distance(targetPos,transform.position) <= 0.01) {
			i++;
		}
	}
}
