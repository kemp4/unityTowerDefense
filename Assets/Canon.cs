using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Canon : MonoBehaviour {

	public Transform canon;
	public bool active;
	public bool isPlaced;
	public Grid grid;
	public Transform bullet1;
	public float loadSpeed;
	public float range;
	public int pointsValue;


	private float maxLoad = 100;
	private float loadProgress = 101;
	private GUIScript guiScript;


	//public Transsform bullet2;
	// Use this for initialization
	void Start () {
		GameObject guiCanvas = GameObject.Find ("GUI");
		guiScript = guiCanvas.GetComponent <GUIScript>();
	}

	// Update is called once per frame
	void Update () {
		if (!isPlaced) {
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3Int cord = grid.WorldToCell (mouseWorldPos);
			transform.position = grid.GetCellCenterWorld(cord);
		}
		if (isPlaced && active) {
			var enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Enemy").OrderBy (go => Vector3.Distance(go.transform.position,transform.position))).ToArray();
			if (enemies.Length > 0) {
				var nearestEnemy = enemies [0];

				var dy = nearestEnemy.transform.position.y - transform.position.y;
				var dx = nearestEnemy.transform.position.x - transform.position.x;
				float angle = (Mathf.Atan2 (dy, dx) * 180) / Mathf.PI;
				// Debug.Log (angle);
				transform.rotation = Quaternion.AngleAxis (angle - 90, Vector3.forward);
		
				if (Vector3.Distance (nearestEnemy.transform.position, transform.position) <= range) {
					if (loadProgress >= maxLoad) {
						Transform newBullet = Instantiate (bullet1, transform.position, Quaternion.identity);
						Bullet newBulletScript = newBullet.GetComponent<Bullet> ();
						newBulletScript.enemyTarget = nearestEnemy;
						loadProgress = 0;
					} else {
						loadProgress += loadSpeed * Time.deltaTime;
					}
				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			if (!active && !isPlaced) {
				Destroy (gameObject);
			}
		}
	}

	bool legalPlace ()
	{			
		var towers = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Tower").Where (go => Vector3.Distance(go.transform.position,transform.position)<=0.02)).ToArray();
		var roads = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Road").Where (go => Vector3.Distance(go.transform.position,transform.position)<=0.02)).ToArray();
		if (towers.Length > 0 || roads.Length > 0) {
			return false;
		}
		return true;
	}

	void OnMouseDown(){


		
		if (!active && isPlaced) {
			// Stworz nowy canon 
			Transform boo = Instantiate (canon, new Vector3 (0, 0, 0), Quaternion.identity);
			Canon newTowerScript = boo.GetComponent<Canon> ();
			newTowerScript.active = false;
			newTowerScript.isPlaced = false;
			newTowerScript.grid = grid;
			//newTowerScript.loadSpeed = loadSpeed;
			newTowerScript.range = range;
		}
		if (!active && !isPlaced) {
			if (legalPlace ()) {
				if (guiScript.dollars - this.pointsValue >= 0) {
					guiScript.dollars -= this.pointsValue;
					active = true;
					isPlaced = true;
				}
			}
		}
	}
}
