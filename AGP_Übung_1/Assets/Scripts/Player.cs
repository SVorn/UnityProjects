using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private GameObject bullet;

	[SerializeField]
	private Transform BulletParent;

	[SerializeField]
	private float nextBullet;
	[SerializeField]
	private float fireRate;

	private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("a")){
			transform.position -= new Vector3(speed * Time.deltaTime,0f,0f);
		}	
		if(Input.GetKey ("d")){
			transform.position += new Vector3(speed * Time.deltaTime,0f,0f);
		}
		if(Input.GetKey ("w")){
			transform.position += new Vector3(0f,speed * Time.deltaTime, 0f);
		}
		if(Input.GetKey ("s")){
			transform.position -= new Vector3(0f,speed * Time.deltaTime, 0f);
		}
		if(Input.GetKey ("space")&& Time.time > nextBullet){
			nextBullet = Time.time + fireRate;
			GameObject bull = Instantiate(bullet);
			bull.transform.position = BulletParent.position;
		}

	}
	void OnCollisionEnter(Collision coll){
		Debug.Log("Collision");
		Destroy(coll.gameObject, 0.1f);
		Destroy(gameObject);
		gameController.GameOver();	
	}	
}

