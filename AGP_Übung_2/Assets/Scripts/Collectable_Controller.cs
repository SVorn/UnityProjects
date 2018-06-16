using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Controller : MonoBehaviour {

	[SerializeField]
	private int scoreValue;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

/*	void OnCollision2DEnter(Collision2D col){
		Debug.Log("Collision");
		Destroy(this.gameObject);
		gameController.NewScore(scoreValue);

	}*/
}
