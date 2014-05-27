using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public Transform mesh;
	public float forceFly;
	private Animator animatorPlayer;

	private float currentTimeToAnim;
	private bool inAnim = true;
	private GameController gameController;


	void Start () {
	
		animatorPlayer = mesh.GetComponent<Animator> ();
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}
	

	void Update () {
	
			if (Input.GetMouseButtonDown (0) && gameController.GetCurrentState () == GameStates.INGAME && 
						gameController.GetCurrentState () != GameStates.GAMEOVER) {
						
						inAnim = true;
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (new Vector2 (0, 1) * forceFly);
				}
		else if (Input.GetMouseButtonDown (0) && gameController.GetCurrentState () == GameStates.TUTORIAL) {
			if(gameController.CanPlay()){
				Restart();	
			}


		}
			
		animatorPlayer.SetBool ("callFly", inAnim);

	Vector3 positionPlayer = transform.position;
			if (positionPlayer.y > 4) {
					positionPlayer.y = 4;
					transform.position = positionPlayer;
		}
	
		if (gameController.GetCurrentState () == GameStates.TUTORIAL) {
			inAnim = true;
		}

			if (gameController.GetCurrentState () != GameStates.INGAME && gameController.GetCurrentState () != GameStates.GAMEOVER) {
					rigidbody2D.gravityScale = 0;
					return;
				} 
			else {
					rigidbody2D.gravityScale = 1;
				}

			if (inAnim && gameController.GetCurrentState () != GameStates.TUTORIAL) {
						currentTimeToAnim += Time.deltaTime;
						if (currentTimeToAnim > 0.4f) {
								currentTimeToAnim = 0;
								inAnim = false;
						}
				} 
	

		if (gameController.GetCurrentState () == GameStates.INGAME) {
			if (rigidbody2D.velocity.y < 0) {
					mesh.eulerAngles -= new Vector3 (0, 0, 2f);
					if (mesh.eulerAngles.z < 10 && mesh.eulerAngles.z > 30)
							mesh.eulerAngles = new Vector3 (0, 0, 10);
						} 
					else if (rigidbody2D.velocity.y > 0) {
							mesh.eulerAngles += new Vector3 (0, 0, 2f);
					if (mesh.eulerAngles.z > 30)
							mesh.eulerAngles = new Vector3 (0, 0, 0);
						}
					}

					else if (gameController.GetCurrentState () == GameStates.GAMEOVER) {
						mesh.eulerAngles -= new Vector3 (0, 0, 2f);
					if (mesh.eulerAngles.z < 10 && mesh.eulerAngles.z > 30)
						mesh.eulerAngles = new Vector3 (0, 0, 10);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		gameController.CallGameOve ();
		}

	void OnTriggerEnter2D(Collider2D coll) {
		gameController.CallGameOve ();
	}

	public void RestartRotation(){
		mesh.eulerAngles = new Vector3 (0, 0, 0);
	}

	public void Restart(){
		if(gameController.GetCurrentState() != GameStates.GAMEOVER){
			gameController.RestartGame();
			gameController.StartGame();
		}

	}
}
