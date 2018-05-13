using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField]
	private float speed;
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
		transform.position += new Vector3 (0f, speed * Time.deltaTime,0f);
	}

	void OnCollisionEnter(Collision col){
		Debug.Log("Collision");
		Destroy(col.gameObject, 0.1f);
		Destroy(this.gameObject);
		gameController.NewScore(scoreValue);

	}
}
