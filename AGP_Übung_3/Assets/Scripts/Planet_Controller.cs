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
	// Use this for initialization
	void Start () {
	}

	void Update(){
		destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
		transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, scaleSpeed*Time.deltaTime);

		
	}
	
	// Update is called once per frame
	void LateUpdate () {
	//	destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
	//	transform.localScale = Vector3.MoveTowards(transform.localScale, destinationScale, scaleSpeed*Time.deltaTime);

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

/*	public void IncreaseSize(Vector3 destinationScale,float time){
		// need a loop i think
		Debug.Log("hi");
		{
		transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, currentTime/time);
		currentTime += Time.deltaTime;
		}
	}*/

	public void Increment(float increment){
		value = value + increment;
	//	destinationScale = new Vector3(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
	}
}

