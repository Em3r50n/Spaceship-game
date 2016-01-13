﻿using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

	public const int VELOCIADE_TIRO = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		transform.Translate(0, VELOCIADE_TIRO * Time.deltaTime, 0);

		if (transform.position.z >= 9) {
			Destroy(gameObject);
		}

	}
}