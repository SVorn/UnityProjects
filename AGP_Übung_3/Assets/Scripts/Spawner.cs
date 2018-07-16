using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject invader;

	[SerializeField]
	private float spawnDistance;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnInvader());
	}
	
	//Method to Spawn the Invaders

	IEnumerator SpawnInvader(){
		Vector3 pos = Random.onUnitSphere * 20f;
		Instantiate(invader, pos, Quaternion.identity);

		yield return new WaitForSeconds(5f);

		StartCoroutine(SpawnInvader());
	}
}
