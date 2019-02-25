using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbarManager : MonoBehaviour {

	public float hpRatio = 1.0f;
	// Use this for initialization
	private GameObject hp;
	private Vector3 startScale;

	void Start () {
		hp = transform.Find ("hp").gameObject;
		startScale = hp.transform.localScale;

	}

	// Update is called once per frame
	void Update () {
		hp.transform.localScale = new Vector3(startScale.x*hpRatio, startScale.y, startScale.z);
	}
}
