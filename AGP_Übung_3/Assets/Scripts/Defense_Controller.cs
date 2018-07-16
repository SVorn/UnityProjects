using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense_Controller : MonoBehaviour {

	[SerializeField]
	private GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
		StartCoroutine(Shooting());
	}
	
	IEnumerator Shooting(){
		Vector3 pos = new Vector3(transform.position.x, transform.position.y,transform.position.z);
		Instantiate(bulletPrefab, pos, transform.rotation);

		yield return new WaitForSeconds(5f);

		StartCoroutine(Shooting());
	}
}
