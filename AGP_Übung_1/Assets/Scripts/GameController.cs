using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Text scoreText;
	
	[SerializeField]
	private Text gameOverText;
	
	[SerializeField]
	private Text restartText;
	private bool gameOver;
	private bool restart;
	private int score;
	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		score = 0;
		restartText.text = "";
		gameOverText.text = "";
		scoreText.text = "Score: "+ score;
	}
	
	// Update is called once per frame
	void Update () {
		if(restart){
			if(Input.GetKey (KeyCode.F)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
			
        if(gameOver){
			restartText.text = "Try again - Press 'F'";
			restart = true;
		}
	}

	public void NewScore(int newValue){
		score += newValue;
		UpdateScore();
	}

	void UpdateScore(){
		scoreText.text ="Score: "+ score;
	}

	public void GameOver(){
		gameOverText.text = "You died";
		gameOver = true;
	}
}


