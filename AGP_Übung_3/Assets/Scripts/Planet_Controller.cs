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
	[SerializeField]
	private float increment;
	private float currentTime = 0f;

	private Vector3 destinationScale;

	private float time;

	private float speed = 10f;
	// Use this for initialization
	void Start () {
	}

	void Update(){
		
	//Control the Planet	
	/*	if(Input.GetKey(KeyCode.A)){
			transform.Rotate(0,-speed * Time.deltaTime,0f);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(0,speed*Time.deltaTime,0f);
		}
		if(Input.GetKey(KeyCode.W)){
			transform.Rotate(speed * Time.deltaTime,0f,0f);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Rotate(-speed*Time.deltaTime,0f,0f);
		}*/



	}
	
	// Update is called once per frame
	void FixedUpdate () {

	//Old Planet Gravity, allows for cool fly in moments!!!

	/*	Collider[] colliders = Physics.OverlapSphere(transform.position, pullRadius, layersToPull);

		foreach(var collider in colliders){
			Rigidbody rb = collider.GetComponent<Rigidbody>();

			if(rb == null) continue;

			Vector3 direction = transform.position - collider.transform.position;

			if(direction.magnitude < minRadius) continue;
			
			float distance = direction.sqrMagnitude*distanceMultiplier + 1;


			rb.AddForce(direction.normalized * (gravityPull/distance)* rb.mass * Time.deltaTime);
			}*/

	}

	public void IncreaseSize(){
		// need a loop i think
		Debug.Log("hi");
		{
		transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, currentTime/time);
		currentTime += Time.deltaTime;
		}
	}
}

