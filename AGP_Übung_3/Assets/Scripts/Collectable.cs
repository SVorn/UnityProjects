using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	public GameObject planet;
	private Planet_Controller planet_Controller;

	[SerializeField]
	private float incrValue;


	
	// Use this for initialization
	void Awake () {
		planet_Controller = planet.GetComponent<Planet_Controller>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.tag =="Player"){
		Debug.Log("Hit");
		planet_Controller.Increment(incrValue);
		//Destroy(this.gameObject);
		}
	}
}
