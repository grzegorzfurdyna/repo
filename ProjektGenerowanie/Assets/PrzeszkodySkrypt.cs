﻿using UnityEngine;
using System.Collections;

public class PrzeszkodySkrypt : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += new Vector3 (speed, 0, 0)*Time.deltaTime;

		if (transform.position.x < -78) 
			{
			gameObject.SetActive(false);

			}

	}
}
