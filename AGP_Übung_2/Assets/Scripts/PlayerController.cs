using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	
	private Rigidbody2D rigidbodyPlayer;

	private Animator playerAnimator;

	[SerializeField]
	private float speed;

	private bool facingRightDirection;
	// Use this for initialization
	void Start () {
		facingRightDirection = true;
		rigidbodyPlayer = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	//FixedUpdate when dealing with different fps
	void Update () {
		float horizontal = Input.GetAxis("Horizontal"); //control via InputManager -> multiple control possibilities
		//horizontal values from -1 to 1
		//Debug.Log(horizontal);
		Movement(horizontal);
		changeDirection(horizontal);
	}

	private void Movement(float horizontal){
	//	rigidbodyPlayer.velocity = Vector2.left; //.left = x = -1, y = 0;
		rigidbodyPlayer.velocity = new Vector2(horizontal * speed, rigidbodyPlayer.velocity.y);

		playerAnimator.SetFloat("moveSpeed", Mathf.Abs(horizontal));
	}

	private void changeDirection(float horizontal){
		if(horizontal > 0 && !facingRightDirection || horizontal < 0 && facingRightDirection){
			facingRightDirection = !facingRightDirection;

			Vector3 playerScale = transform.localScale;

			//only works when scale x set to -1 at start?? -> solved its the if-condition
			playerScale.x *= -1;

			transform.localScale = playerScale;
		}
	}

}
