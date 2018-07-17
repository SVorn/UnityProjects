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

<<<<<<< HEAD
	float timeToMove = 5f;

	private Vector3 destinationScale;
=======

	private Vector3 destinationScale;

	[SerializeField]
	private float scaleSpeed;
>>>>>>> branch

	private float value = 0f;

	private float speed = 10f;

	private float amountOfHits;

	private GameController gameController;
	
	[SerializeField]
<<<<<<< HEAD
	private float scaleSpeed;

	private float value = 0f;

	private float speed;
=======
	private GameObject destroyEffect;

	Vector3 vec3 = new Vector3(0,0,0);

>>>>>>> branch
	// Use this for initialization
	void Start () {
		amountOfHits = 0;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update(){
<<<<<<< HEAD
	/*	if(currentTime <= timeToMove){
			currentTime += Time.deltaTime;
		}
		value = 0;*/

	//	destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
/*		float i = 0f;
		while(i < 1.0){
			i += Time.deltaTime * scaleSpeed;
			transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, i);
		
		}
		value = 0;*/
	}
	
	// Update is called once per frame
/*	void LateUpdate () {
	//	destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
	//	transform.localScale = Vector3.MoveTowards(transform.localScale, destinationScale, scaleSpeed*Time.deltaTime);

	//Old Planet Gravity, allows for cool fly in moments!!!

		Collider[] colliders = Physics.OverlapSphere(transform.position, pullRadius, layersToPull);

		foreach(var collider in colliders){
			Rigidbody rb = collider.GetComponent<Rigidbody>();

			if(rb == null) continue;

			Vector3 direction = transform.position - collider.transform.position;
=======
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
>>>>>>> branch


	public void Increment(float increment){
		Debug.Log("Increment");
		value += increment;
	//	destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
	}

<<<<<<< HEAD
			rb.AddForce(direction.normalized * (gravityPull/distance)* rb.mass * Time.deltaTime);
			}

	}*/

	public void Increment(float increment){
		Debug.Log("Increment");
		value = value + increment;
		Scale();
	//	destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
	}

	void Scale(){
		Debug.Log("Scale");
		destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
		float i = 0f;
		while(i < 1.0){
			i += Time.deltaTime * scaleSpeed;
			transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, i);
		
		}
		value = 0;
=======
	//Planet can be hit to 3 times, after that it "destroyed" -> no actual destroy because it is an asset
	void TakesHit(){
		if(amountOfHits >= 2){
			Debug.Log("End Game");
			Instantiate(destroyEffect, vec3 ,transform.rotation);
			gameController.GameOver();
			gameObject.active = false;
		}
		amountOfHits += 1;
		Increment(1);
		Debug.Log(amountOfHits);
>>>>>>> branch
	}
}

