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
		Vector3 destinationScale = new Vector3(12f,12f,12f);
		float time = 100f;

		transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, currentTime/time);
		currentTime += Time.deltaTime;
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
}

