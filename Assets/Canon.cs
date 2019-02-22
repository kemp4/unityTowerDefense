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
	private float loadSpeed=5;
	private float maxLoad = 100;
	private float loadProgress = 101;
	private float range = 5;
	//public Transsform bullet2;
	// Use this for initialization
	void Start () {
		
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
			var nearestEnemy = enemies [0];
			if (Vector3.Distance (nearestEnemy.transform.position, transform.position) <= range) {
				if (loadProgress >= maxLoad) {
					Transform boo = Instantiate (bullet1, transform.position, Quaternion.identity);
					Bullet foo = boo.GetComponent<Bullet> ();
					foo.enemyTarget = nearestEnemy;

				}
			}
		}
	}

	void OnMouseDown(){
		if (!active && isPlaced) {
			// Stworz nowy canon 
			Transform boo = Instantiate (canon, new Vector3 (0, 0, 0), Quaternion.identity);
			Canon foo = boo.GetComponent<Canon> ();
			foo.active = false;
			foo.isPlaced = false;
			foo.grid = grid;
		}
		if (!active && !isPlaced) {
			//if(legalPlace())
			active = true;
			isPlaced = true;
		}
	}
}
