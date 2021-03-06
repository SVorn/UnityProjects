﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private Vector3 camOffset;
	// Use this for initialization
	void Start () {
		camOffset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + camOffset;
	}
}
