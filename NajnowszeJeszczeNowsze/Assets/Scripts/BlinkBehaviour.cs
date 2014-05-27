using UnityEngine;
using System.Collections;

public class BlinkBehaviour : MonoBehaviour {

	public float rateBlink;
	private float currentRateBlink;

	void Start () {
	
	}
	

	void Update () {
		currentRateBlink += Time.deltaTime;

		if (currentRateBlink > rateBlink) {
			renderer.enabled = !renderer.enabled;		
			currentRateBlink = 0;
		}
	}
}
