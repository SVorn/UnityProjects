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

	float timeToMove = 5f;

	private Vector3 destinationScale;

	[SerializeField]
	private float scaleSpeed;

	private float value = 0f;

	private float speed;
	// Use this for initialization
	void Start () {
	}

	void Update(){
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

			if(direction.magnitude < minRadius) continue;
			
			float distance = direction.sqrMagnitude*distanceMultiplier + 1;


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
	}
}

