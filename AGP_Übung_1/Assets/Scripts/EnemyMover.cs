using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	public Renderer rend;

	[SerializeField]
	private float speed;

	YieldInstruction WaitForSeconds;
	// Use this for initialization
	void Start () {
	//	rend = GetComponent<Renderer>();
	//	rend.material.shader = Shader.Find("Dissolve_Shader");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0f,-(speed * Time.deltaTime),0f);
	}

/*	void OnCollisionEnter(Collision col){
		float dissolve = Mathf.MoveTowards(0.0f,1.0f,1.0f);
		rend.material.SetFloat("_DissolveFactor", dissolve);
		new WaitForSeconds(2);
		Destroy(gameObject,1f);

	}*/
}
