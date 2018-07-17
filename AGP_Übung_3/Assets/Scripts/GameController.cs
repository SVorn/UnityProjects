using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Text gameOverText;

	[SerializeField]
	private Text restartText;

	[SerializeField]
	private Text timeText;
	private bool gameOver;
	private bool restart;
	private float startTime;
	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//reload the current scene at restart -> ! if new scene change name to given scene
		if(restart){
			if(Input.GetKey(KeyCode.F)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}

		if(gameOver){
			restartText.text = "You failed to save your Planet - Try again with 'F'";
			restart = true;
		}
		//stop time when game is over
		if(gameOver){
			return;
		} else {
		float t = Time.time - startTime;
		string minutes = ((int) t / 60).ToString();
		string seconds = (t % 60).ToString("f0");

		timeText.text = minutes + " minute and " + seconds + " seconds";
		}
	}
	
	public void GameOver(){
	//	gameOverText.text = "You died";
		gameOver = true;
	//	Time.timeScale = 0; //tried to pause game while dead
	}

}
