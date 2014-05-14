﻿using UnityEngine;
using System.Collections;

public class ObstaclesBehaviour : MonoBehaviour {

	public float speed;

	private GameController gameController;

	private bool passed;


	void Start () {
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}

	void OnEnable(){
		passed = false;
	}
	

	void Update () {
	
		if (gameController.GetCurrentState () != GameStates.INGAME)
		return;
		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
		if(transform.position.x < -5.5){
		gameObject.SetActive(false);
		}

		if (transform.position.x < gameController.player.position.x && !passed) {
			passed = true;		
			gameController.AddScore();
		}
	}
}
