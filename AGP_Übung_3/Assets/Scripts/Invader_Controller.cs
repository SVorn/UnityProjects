using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader_Controller : MonoBehaviour {

	public SphereCollider SphereCollider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		Destroy(col.gameObject, 2f);
		Destroy(gameObject,2f);
	}
}
