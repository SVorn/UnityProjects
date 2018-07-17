using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour {
/*Needs an counter part to work -> FauxGravityBody */
/*Programmed after a Tutorial by Brackeys(Youtube)*/
	public static FauxGravityAttractor instance;

	private SphereCollider sphereCol;

	[SerializeField]
	private float gravity;
	void Awake ()
	{
		instance = this;
		sphereCol = GetComponent<SphereCollider>();
	}


	public void Attract (Rigidbody body)
	{	//Adds Force to Rigidbody towards itself
		Vector3 targetDirection = (body.position - transform.position).normalized;
		body.AddForce(targetDirection * gravity);

		RotateBody(body);
	}

	public void PlaceOnSurface (Rigidbody body)
	{	//moves body directly on the surface by considering the Sphere Radius(Collider Size)
		body.MovePosition((body.position - transform.position).normalized * (transform.localScale.x * sphereCol.radius));

		RotateBody(body);
	}

	void RotateBody (Rigidbody body)
	{
		Vector3 targetDirection = (body.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.FromToRotation(-1* body.transform.forward, targetDirection) * body.rotation;
		body.MoveRotation (Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime));
	}

}
