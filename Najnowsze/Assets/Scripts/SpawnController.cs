using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {

	public float maxHeight;
	public float minHeight;
	public float maxSpawn;
	public float minSpawn;

	public float rateSpawn;
	private float currentRateSpawn;

	public GameObject stonePrefab;

	public int maxSpawnStones;
	public List<GameObject> stones;

	private GameController gameController;
	

	void Start () {
		for (int i=0; i<maxSpawnStones; i++) {
						GameObject tempStone = Instantiate (stonePrefab) as GameObject;
						stones.Add (tempStone);
						tempStone.SetActive (false);
						}

		currentRateSpawn = rateSpawn;
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}
	

	void Update () {

		if (gameController.GetCurrentState () != GameStates.INGAME)
		return;
		currentRateSpawn += Time.deltaTime;
		rateSpawn = Random.Range (minSpawn, maxSpawn);
		if (currentRateSpawn > rateSpawn) {
					currentRateSpawn = 0;
					Spawn ();
					}
	}


	private void Spawn(){
				
		float randHeight = Random.Range (minHeight, maxHeight);
		GameObject tempStone = null;
		for (int i=0; i<maxSpawnStones; i++) {
				if (stones [i].activeSelf == false) {
						tempStone = stones [i];
						break;
						}
				}
				if (tempStone != null) {
					tempStone.transform.position = new Vector3 (transform.position.x, randHeight, transform.position.y);
					tempStone.SetActive (true);
				}
		}
}
