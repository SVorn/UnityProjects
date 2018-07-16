using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private float turnSpeed;

	private Rigidbody rigidPlayer;

	Vector3 movement;

	[SerializeField]
	private GameObject defensePrefab;
	// Use this for initialization
	void Start () {
		rigidPlayer = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	//	horizontal = Input.GetAxis("Horizontal")* speed * Time.deltaTime;
	//  vertical = Input.GetAxis("Vertical")* speed * Time.deltaTime;
	//transform.Rotate(Vector3.forward*Input.GetAxis("Horizontal")*Time.deltaTime *speed);
	
		
	//Rotate so Player is always moving forward
/*	if(Input.GetKey(KeyCode.A)){
		transform.Rotate(Vector3.forward*1*Time.deltaTime*turnSpeed);
	}
	if(Input.GetKey(KeyCode.D)){
		transform.Rotate(Vector3.forward*-1*Time.deltaTime*turnSpeed);
	}
*/
//calculate direction to move from -1 to 1
	Vector3 targetDir = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f).normalized;
	movement = targetDir*speed;

//Instantiate defense system on player position by pressing space
	Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	if(Input.GetKeyDown(KeyCode.Space)){
		Instantiate(defensePrefab, pos, transform.rotation);
	}
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
		rigidPlayer.MovePosition(rigidPlayer.position + transform.TransformDirection(movement)* Time.fixedDeltaTime);


	//	rigidPlayer.MoveRotation(rigidPlayer.transform.rotation);
		
/*		Vector3 origin = Vector3.zero;

		Quaternion hori = Quaternion.AngleAxis(-horizontal, Vector3.up);
		Quaternion vert = Quaternion.AngleAxis(vertical, Vector3.right);

		Quaternion q = hori * vert;
		rigidPlayer.MovePosition(q*(rigidPlayer.transform.position-origin)+origin);
*/		

		//rigidPlayer.MoveRotation(rigidPlayer.transform.rotation*q);
		//transform.LookAt(Vector3.zero);

	}

}

