using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIScript : MonoBehaviour {

	public Text dollarsUI;
	public Text pointsUI;
	public Text livesUI;
	public Text rlCostUI;
	public Text canonCostUI;
	public Text GameOver;

	public int points = 0;
	public int dollars = 100;
	public int lives = 20;

	Transform goTransform;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//points = 10;
		//dollars=101;
		dollarsUI.text = "" + dollars;
		pointsUI.text = "points: " + points;
		livesUI.text = "" + lives;


		if (dollars < 100) {
			rlCostUI.color = Color.red;
		} else {
			rlCostUI.color = Color.white;
		}

		if (dollars < 20) {
			canonCostUI.color = Color.red;
		} else {
			canonCostUI.color = Color.white;
		}
		if (lives <= 0) {
			GameOver.text= "GAME OVER";
			Time.timeScale = 0;
		}
	}
}
