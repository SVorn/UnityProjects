using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	[SerializeField]
	private float speed;

	private float horizontal = 0f;
	private float vertical = 0f;

	private Rigidbody rigidPlayer;
	// Use this for initialization
	void Start () {
		rigidPlayer = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		vertical = Input.GetAxis("Vertical")* speed * Time.deltaTime;
		horizontal = Input.GetAxis("Horizontal")* speed * Time.deltaTime;

		//Movement(vertical, horizontal);
		//Rotate(Vector3.zero, Vector3.right*vertical*speed*Time.deltaTime,1f);
	}
	

/*	void Movement(float vertical, float horizontal){
		rigidPlayer.velocity = new Vector3(rigidPlayer.velocity.x,vertical * speed, rigidPlayer.velocity.z);
		//transform.position = new Vector3(vertical * speed, 0f, 0f);

		rigidPlayer.velocity = new Vector3(horizontal * speed, rigidPlayer.velocity.y,0f);
	}*/

/*	void Rotate(Vector3 origin, Vector3 axis, float angle){
		Quaternion q = Quaternion.AngleAxis(angle, axis);
		rigidPlayer.MovePosition(q * (rigidPlayer.transform.position - origin)+origin);
		rigidPlayer.MoveRotation(rigidPlayer.transform.rotation*q);
	}*/

	void FixedUpdate(){
		Vector3 origin = Vector3.zero;

		Quaternion hori = Quaternion.AngleAxis(-horizontal, Vector3.up);
		Quaternion vert = Quaternion.AngleAxis(vertical, Vector3.right);

		Quaternion q = hori * vert;
		rigidPlayer.MovePosition(q*(rigidPlayer.transform.position-origin)+origin);
		//rigidPlayer.MoveRotation(rigidPlayer.transform.rotation*q);
		//transform.LookAt(Vector3.zero);
	}

}

