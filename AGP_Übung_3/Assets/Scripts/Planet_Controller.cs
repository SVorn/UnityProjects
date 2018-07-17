using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Controller : MonoBehaviour {
/* 
	[SerializeField]
	private float pullRadius;
	[SerializeField]
	private float gravityPull;
	[SerializeField]
	private float minRadius;
	[SerializeField]
	private float distanceMultiplier;

	public LayerMask layersToPull;
*/

	private float currentTime;


	private Vector3 destinationScale;

	[SerializeField]
	private float scaleSpeed;

	private float value = 0f;

	private float speed = 10f;

	private float amountOfHits;

	private GameController gameController;
	
	[SerializeField]
	private GameObject destroyEffect;

	Vector3 vec3 = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		amountOfHits = 0;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update(){
		destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
		transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, scaleSpeed*Time.deltaTime);
	
	}
	
	void OnCollisionEnter(Collision col){
		if(col.collider.tag == "Invader"){
			Destroy(col.gameObject);
			Debug.Log("Planet dies");
			TakesHit();
			gameController.Warning();
			gameController.LifeBar();
		}
	}


	public void Increment(float increment){
		Debug.Log("Increment");
		value += increment;
	//	destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
	}

	//Planet can be hit to 3 times, after that it "destroyed" -> no actual destroy because it is an asset
	void TakesHit(){
		if(amountOfHits >= 3){
			Debug.Log("End Game");
			Instantiate(destroyEffect, vec3 ,transform.rotation);
			gameController.GameOver();
			gameObject.active = false;
		}
		amountOfHits += 1;
		Increment(1);
		Debug.Log(amountOfHits);
	}
}

