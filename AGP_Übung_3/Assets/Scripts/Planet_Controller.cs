using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Controller : MonoBehaviour {

	[SerializeField]
	private float pullRadius;
	[SerializeField]
	private float gravityPull;
	[SerializeField]
	private float minRadius;
	[SerializeField]
	private float distanceMultiplier;

	public LayerMask layersToPull;

	[SerializeField]
	private float increment;
	private float currentTime = 0f;

	public Vector3 destinationScale;

	public float time;

	private float speed = 10f;
	// Use this for initialization
	void Start () {
	}

	void Update(){
/*		if(currentTime >= 10f){
		transform.localScale += new Vector3(increment, increment, increment);
		currentTime = 0f;
		}
		currentTime += Time.deltaTime;
	}*/
	//Scale the Planet over Time
		
		//float time = 100f;
		//destinationScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
		//destinationScale = new Vector3(20f,20f,20f);
		//IncreaseSize();
		
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
		Collider[] colliders = Physics.OverlapSphere(transform.position, pullRadius, layersToPull);

		foreach(var collider in colliders){
			Rigidbody rb = collider.GetComponent<Rigidbody>();

			if(rb == null) continue;

			Vector3 direction = transform.position - collider.transform.position;

			if(direction.magnitude < minRadius) continue;
			
			float distance = direction.sqrMagnitude*distanceMultiplier + 1;


			rb.AddForce(direction.normalized * (gravityPull/distance)* rb.mass * Time.deltaTime);
			}
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

