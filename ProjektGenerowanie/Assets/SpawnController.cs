using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnController : MonoBehaviour {

	public float maxHeight;
	public float minHeight;

	public float rateSpawn;
	private float currentRateSpawn;

	public GameObject RobKamienie;

	public int maxSpawnKamienie;

	public List<GameObject> kamienie;

	// Use this for initialization
	void Start () {
	
		for (int i=0; i<maxSpawnKamienie; i++) 
		{
			GameObject tempKamien = Instantiate(RobKamienie) as GameObject;
			kamienie.Add(tempKamien);
			tempKamien.SetActive(false);
				}
		currentRateSpawn = rateSpawn;
	}

	// Update is called once per frame
	void Update () {
	
		currentRateSpawn += Time.deltaTime;
		if (currentRateSpawn > rateSpawn) {
			currentRateSpawn=0;
			Spawn ();
				}
	}
	private void Spawn()
	{
		float randHeight = Random.Range(minHeight,maxHeight);

		GameObject tempKamien = null;
		for (int i=0; i<maxSpawnKamienie; i++) 
		{
			if(kamienie[i].activeSelf == false)
			{
				tempKamien = kamienie[i];
				break;
			}
		}

		if (tempKamien != null) 
		{
			tempKamien.transform.position = new Vector3(transform.position.x,randHeight, transform.position.z);
			tempKamien.SetActive(true);	
		}

	}
}
