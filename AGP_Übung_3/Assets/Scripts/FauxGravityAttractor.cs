using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour {

	public static FauxGravityAttractor instance;

	private SphereCollider col;

	void Awake ()
	{
		instance = this;
		col = GetComponent<SphereCollider>();
	}

	public float gravity = -10f;

	public void Attract (Rigidbody body)
	{
		Vector3 targetDirection = (body.position - transform.position).normalized;
		body.AddForce(targetDirection * gravity);

		RotateBody(body);
	}

	public void PlaceOnSurface (Rigidbody body)
	{
		body.MovePosition((body.position - transform.position).normalized * (transform.localScale.x * col.radius));

		RotateBody(body);
	}

	void RotateBody (Rigidbody body)
	{
		Vector3 targetDirection = (body.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.FromToRotation(-1* body.transform.forward, targetDirection) * body.rotation;
		body.MoveRotation (Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime));
	}

}
