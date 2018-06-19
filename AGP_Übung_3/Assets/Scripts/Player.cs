using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float moveSpeed = 15f;
	private Vector3 moveDir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized;

	}

	void FixedUpdate(){
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir*moveSpeed*Time.deltaTime));
	}
}
