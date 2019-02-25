using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public Grid grid;
	public int points=0;
	public int gold=100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3Int cord = grid.WorldToCell (mouseWorldPos);
		//Debug.Log (cord);
	}
}
