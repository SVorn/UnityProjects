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

	private float amountOfTowers;

	// Use this for initialization
	void Start () {
		amountOfTowers = 0;
		rigidPlayer = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	//calculate direction to move from -1 to 1
	Vector3 targetDir = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f).normalized;
	movement = targetDir*speed;

	//Instantiate defense system on player position by pressing space
	Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	if(Input.GetKeyDown(KeyCode.Space)){
		Instantiate(defensePrefab, pos, transform.rotation);
		amountOfTowers += 1;
		}
		
	}
	
	

	void FixedUpdate(){
		rigidPlayer.MovePosition(rigidPlayer.position + transform.TransformDirection(movement)* Time.fixedDeltaTime);



	}

}