using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet : MonoBehaviour {

	public GameObject enemyTarget;
	public float velocity = 3;
	public int damage=10;
	public float aoeRange; 
	public GameObject explosion;

	private Quaternion baseRotation;

	// Use this for initialization
	void Start () {
		baseRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyTarget == null) {
			Destroy (gameObject);
		} else {
			transform.rotation =baseRotation;
			// Debug.Log (angle);
			//transform.Translate (-transform.position);
			Vector3 targetPos = enemyTarget.transform.position;
			Vector3 targetDir = (targetPos - transform.position).normalized;
			transform.Translate (targetDir * Time.deltaTime * velocity);


			if (Vector3.Distance (targetPos, transform.position) <= 0.02) {

				if (explosion != null) { // emit explosion if exist
					var newExplosion = Instantiate (explosion, transform.position, Quaternion.identity);
					newExplosion.transform.Translate (new Vector3 (0.0f, 0.0f, -3.0f));
					Destroy (newExplosion, 2.0f);
				}
				EnemyScript foo = enemyTarget.GetComponent<EnemyScript> ();
				foo.damaged (this);
				if (aoeRange > 0.02) {
					var enemies = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Enemy")
						.Where (go => Vector3.Distance (go.transform.position, transform.position) <= aoeRange)).ToArray ();
					foreach (var affectedEnemy in enemies) {
						affectedEnemy.GetComponent<EnemyScript> ().damaged (this);
					}
				}
				Destroy (gameObject);
			} else {
				var tempPos = transform.position;
				var dy = enemyTarget.transform.position.y - transform.position.y;
				var dx = enemyTarget.transform.position.x - transform.position.x;
				float angle = (Mathf.Atan2 (dy, dx) * 180) / Mathf.PI;

				//transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
				transform.rotation = Quaternion.AngleAxis (angle - 90, Vector3.forward);
				//transform.position = tempPos;
			}
		}
	}
}
