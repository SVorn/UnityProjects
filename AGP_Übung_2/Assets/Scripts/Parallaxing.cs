using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	
	public Transform[] backgrounds; // Array of all backgrounds to be parallaxed
	private float[] amountOfParallax; //proportion of camera movement
	
	
	public float smoothing;  //smoothness of the effect
	
	private Transform camera;
	private Vector3 preCamPos; //position of camera in the frame before

	//Is called before Start() -> good if i need references
	void Awake(){
		camera = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		preCamPos = camera.position;

		amountOfParallax = new float[backgrounds.Length]; //Array as long as our backgrounds

		for (int i = 0; i < backgrounds.Length; i++){
			amountOfParallax[i] = backgrounds[i].position.z*-1; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		//parallay is the opposite of camera movement!!!
		for (int i = 0; i < backgrounds.Length; i++){
			float parallax = (preCamPos.x - camera.position.x) * amountOfParallax[i];
			float backgroundTargetPosX = backgrounds[i].position.x + parallax; //set target position x
			//assign the target position 
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			
			//fade by using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}		
		//renew preCamPos
		preCamPos = camera.position;
	}
}
