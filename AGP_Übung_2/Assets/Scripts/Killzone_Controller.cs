using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone_Controller : MonoBehaviour {

	private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player"){
		Debug.Log("Spieler sollte sterben");
		Destroy(col.gameObject, 2f);
		gameController.GameOver();
		//SceneManager.LoadScene("Main");
		}
	}
}
