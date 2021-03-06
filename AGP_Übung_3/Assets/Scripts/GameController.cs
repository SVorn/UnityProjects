﻿using System.Collections;
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

	[SerializeField]
	private Text warningText;

	[SerializeField]
	private Text lifeText;
	private bool gameOver;
	private bool restart;
	private float startTime;
	private float amountOfLife;
	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		warningText.text = "";
		startTime = Time.time;
		amountOfLife = 3;
		lifeText.text = "Life: " + amountOfLife;
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

		timeText.text = minutes + " min & " + seconds + " sec";
		}
	}
	
	public void GameOver(){
	//	gameOverText.text = "You died";
		gameOver = true;
	//	Time.timeScale = 0; //tried to pause game while dead
	}

	public void Warning(){
	//	Debug.Log("Warning");
		warningText.text = "Warning! You've been hit - The Alien substance makes the planet grow";
	}

	public void LifeBar(){
		amountOfLife = amountOfLife - 1;
		Debug.Log(amountOfLife);
		lifeText.text = "Life: " + amountOfLife;	
	}

}
