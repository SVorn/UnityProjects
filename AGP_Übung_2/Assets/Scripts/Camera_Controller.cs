using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

	public GameObject Player;

	private Vector3 cameraOffset;
	// Use this for initialization
	void Start () {
		cameraOffset = transform.position - Player.transform.position;
	}
	
	// LateUpdate is called after Update each frame
	void LateUpdate () {
		transform.position = Player.transform.position + cameraOffset;
	}
}
