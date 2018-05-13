using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Controller : MonoBehaviour {

	[SerializeField]
	private float scrollSpeed;
	[SerializeField]
	private float SizeY;

	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, SizeY);
		transform.position = startPosition + Vector3.down * newPosition;
	}
}
