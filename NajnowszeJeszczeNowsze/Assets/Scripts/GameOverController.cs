using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public TextMesh score;
	public TextMesh bestScore;

	//public Renderer[] medals;

	public GameObject content;
	public GameObject title;

	public GameObject newScore;

	private float currentTimeGameOver;

	void Start () {
		HideGameOver ();
	}
	
	// Update is called once per frame
	void Update () {
		if (content.activeSelf && content.GetComponent<Animator> ().GetBool ("CallGameOver")) {
			currentTimeGameOver += Time.deltaTime;
			if(currentTimeGameOver > 1) {
				content.GetComponent<Animator> ().SetBool ("CallGameOver", false);
				title.GetComponent<Animator> ().SetBool ("CallGameOver", false);
				currentTimeGameOver = 0;
			}
		}
	}

	public void SetGameOver(int scoreInGame){
		if (scoreInGame > PlayerPrefs.GetInt ("Score")) {
						PlayerPrefs.GetInt ("Score", scoreInGame);
						newScore.SetActive (true);
				} else {
			newScore.SetActive(false);		
		}
		score.text = scoreInGame.ToString();

		bestScore.text = PlayerPrefs.GetInt("Score").ToString();

		content.SetActive (true);
		title.SetActive (true);

		content.GetComponent<Animator> ().SetBool ("CallGameOver", true);
		title.GetComponent<Animator> ().SetBool ("CallGameOver", true);
	}

	public void HideGameOver(){

		content.SetActive (false);
		title.SetActive (false);

	}
}
