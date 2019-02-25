using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	public Transform enemy ;
	public Text waveUI;
	public Text timeToWaveUI;
	private int enemiesPerWave = 20;
	private int enemyIndex = 0 ;
	private int waveNumber = 0;
	private int timeToWave;
	// Use this for initialization

	void Start()
	{
		InvokeRepeating("spawnEnemy", 1.0f, 0.6f);
	}

	void spawnEnemy()
	{
		enemyIndex++;

		var bar = Instantiate(enemy, (transform.position), Quaternion.identity);
		EnemyScript foo = bar.GetComponent<EnemyScript> ();
		foo.pointsValue = (int)(5*(1+(float)(waveNumber)/5.0f));
		foo.health = (int)(100*(1+(float)(waveNumber)/5.0f));
		foo.MAX_HEALTH = (int)(100*(1+(float)(waveNumber)/5.0f));
		if (enemyIndex >= enemiesPerWave) {
			enemyIndex = 0;
		//	waveUI.text = "wave: "+waveNumber;
		
			enemiesPerWave = (int)(20*(1+(float)(waveNumber)/5.0f));
			CancelInvoke ("spawnEnemy");
			InvokeRepeating("spawnEnemy", 10.0f, 0.6f);
			InvokeRepeating("countToWave", 0.0f, 1.0f);
			timeToWave = 10;
		}
	}

	void countToWave(){
		timeToWave--;
		timeToWaveUI.text = "Next wave in: " + timeToWave;
		if (timeToWave <= 0) {
			CancelInvoke ("countToWave");
			waveNumber++;
			waveUI.text = "wave: "+waveNumber;

		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
