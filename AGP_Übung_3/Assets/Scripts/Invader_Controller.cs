using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Invader_Controller : MonoBehaviour {

	public SphereCollider SphereCollider;

	[SerializeField]
	private float invaderHeight;

	public GameObject marker;

	private Vector3 hitPos;

	private bool isCreated = false;

	private GameController gameController;
	
	[SerializeField]
	private GameObject destroyEffect;

	Vector3 vec3 = new Vector3(0,0,0);

	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

		//shoots out a ray in the moving direction
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,invaderHeight)){
			if(hit.collider.tag == "Planet"){
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* hit.distance, Color.green);
				Debug.Log("Rayhit");
				hitPos = hit.point;
				DrawTrajectory(hitPos);
			} 
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.collider.tag == "Planet"){
		Debug.Log("Planet dies");
		Destroy(col.gameObject);
		Instantiate(destroyEffect, vec3 ,transform.rotation);
		gameController.GameOver();
		}
		Destroy(gameObject);
	}

	void DrawTrajectory(Vector3 hitPos){
		if(!isCreated){
		Instantiate(marker, hitPos, transform.rotation);
		isCreated = true;
		}
	}
}
