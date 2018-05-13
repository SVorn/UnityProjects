using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private GameObject enemy;

	
	[SerializeField]
	private float speed;

	private bool destroyed;

	//Eigentlich nur ein Vector2 nötig?
	private Vector2 enemyPos;
	[SerializeField]
	private float spawnTime = 4f;

	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	
	}
	
	// Update is called once per frame

	void Update(){
	
	}

	void Spawn () {
		
		Debug.Log("Spawn");
		enemyPos = new Vector2(Random.Range(-7f,7f),Random.Range(10f,20f));
		Instantiate(enemy,enemyPos,Quaternion.identity);
		

	}
}
