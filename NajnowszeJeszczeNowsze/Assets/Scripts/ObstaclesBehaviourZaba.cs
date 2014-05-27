using UnityEngine;
using System.Collections;

public class ObstaclesBehaviourZaba : MonoBehaviour {

	public float speed;
	public float speed2;
	public float up;
	public float down;
	public bool jumpable = true;
	float jumpForce = 100f;	/// siła skakania


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
		if(jumpable == true) /// Jesli można skakać to...
		{
			jumpable = false;//// Nie można skakać
			
			rigidbody2D.AddForce(new Vector2(0f, jumpForce)); /// Określenie siły skoku
			//yield return new WaitForSeconds (1);
			System.Threading.Thread.Sleep(1);
			jumpable = true;
		}

		if(transform.position.x < -5.5){
		gameObject.SetActive(false);
		}

		if (transform.position.x < gameController.player.position.x && !passed) {
			passed = true;		
			gameController.AddScore();
		}
	}

}
