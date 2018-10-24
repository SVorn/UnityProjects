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

	private Planet_Controller planet_Controller;

	public GameObject planet;

	
	// Use this for initialization
	void Start () {
		planet_Controller = planet.GetComponent<Planet_Controller>();
		
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

/*	void OnCollisionEnter(Collision col){
		Destroy(gameObject);
		if(col.collider.tag == "Planet"){
		Debug.Log("Planet dies");
		planet_Controller.TakesHit();
		}
	}*/

	void DrawTrajectory(Vector3 hitPos){
		if(!isCreated){
		Instantiate(marker, hitPos, transform.rotation);
		isCreated = true;
		}
	}
}
