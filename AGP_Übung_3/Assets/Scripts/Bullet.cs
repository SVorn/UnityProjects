using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	//shoot bullet into negative forward direction of the object
	transform.position += transform.forward*(-speed*Time.deltaTime);
	Destroy(gameObject,2f);
	}
	//destroy Invaders
	void OnCollisionEnter(Collision col){
		Destroy(col.gameObject);
	}
}
