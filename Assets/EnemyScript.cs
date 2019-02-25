using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	private GameObject[] roads;
	public int health = 100;

	public int pointsValue;

	public int MAX_HEALTH = 100;

	//private GUIScript guiScript;
	private int i = 0;

	private GameObject hpBar;
	private GUIScript guiScript;
	// Use this for initialization
	void Start () {

		GameObject guiCanvas = GameObject.Find ("GUI");
		guiScript = guiCanvas.GetComponent <GUIScript>();
		roads = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Road").OrderBy (go => go.name)).ToArray();
		hpBar = transform.Find ("HPbar").gameObject;

	}

	// Update is called once per frame
	void Update () {
		Vector3 targetPos = roads [i].transform.position;
		Vector3 targetDir = (targetPos - transform.position).normalized;
		transform.Translate(targetDir * Time.deltaTime);
		if (Vector3.Distance(targetPos,transform.position) <= 0.01) {
			i++;
		}
		if (i >= roads.Length) {
			guiScript.lives--; 
			Destroy (gameObject);
		}
	}

	GameObject dollars;

	public void damaged(Bullet bullet) {
		this.health -= bullet.damage;
		if (this.health <= 0) {

			guiScript.points += this.pointsValue; 
			guiScript.dollars += this.pointsValue;

			Destroy (gameObject); //smierc
		}
		hpBar.GetComponent<HPbarManager> ().hpRatio=(float)health/(float)MAX_HEALTH;
	}
}
